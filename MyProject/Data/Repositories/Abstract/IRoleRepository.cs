using MyProject.Models;

namespace MyProject.Data.Repositories.Abstract
{
    public interface IRoleRepository
    {
        Task<ApplicationRole> GetByIdAsync(string id);
        Task<ApplicationRole> GetByNameAsync(string roleName);
        Task<IEnumerable<ApplicationRole>> GetAllAsync();
        Task AddAsync(ApplicationRole role);
        Task UpdateAsync(ApplicationRole role);
        Task DeleteAsync(ApplicationRole role);
    }
}
