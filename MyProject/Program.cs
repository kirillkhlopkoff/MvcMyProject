using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//подключаем контекст БД
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(
    "Server=(localdb)\\MSSQLLocalDB;Database=MyProjectDB; Persist Security Info=false;Trusted_Connection=True;MultipleActiveResultSets=true;"
    )); ;
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

//настраиваем authentication cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "myCompanyAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Administrator"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthorization();


app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(name: "admin", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"); //тут нужно будет создать зону админа как в прошлом уроке
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}"); //это стандарт
    endpoints.MapControllerRoute(name: "account", pattern: "{controller=Account}/{action=Index}/{id?}"); // это для аккаунтконтроллера
});

app.Run();
