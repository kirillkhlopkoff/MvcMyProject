using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.Data.Repositories.Abstract;
using MyProject.Models;

namespace MyProject.Data.Repositories.EF
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<ApplicationUser> GetByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task AddAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to create user: {string.Join(", ", result.Errors)}");
            }
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to delete user: {string.Join(", ", result.Errors)}");
            }
        }
    }
}
