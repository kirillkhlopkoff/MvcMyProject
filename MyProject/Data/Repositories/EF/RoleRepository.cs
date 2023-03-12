using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.Data.Repositories.Abstract;
using MyProject.Models;

namespace MyProject.Data.Repositories.EF
{
    public class RoleRepository: IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleRepository(ApplicationDbContext context, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<ApplicationRole> GetByIdAsync(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public async Task<ApplicationRole> GetByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public async Task<IEnumerable<ApplicationRole>> GetAllAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task AddAsync(ApplicationRole role)
        {
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to create role: {string.Join(", ", result.Errors)}");
            }
        }

        public async Task UpdateAsync(ApplicationRole role)
        {
            _context.Entry(role).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ApplicationRole role)
        {
            await _roleManager.DeleteAsync(role);
        }
    }

}
