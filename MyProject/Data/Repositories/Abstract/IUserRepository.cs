using MyProject.Models;

namespace MyProject.Data.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<ApplicationUser> GetByUserNameAsync(string userName);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task AddAsync(ApplicationUser user, string password);
        Task UpdateAsync(ApplicationUser user);
        Task DeleteAsync(ApplicationUser user);
    }
}
