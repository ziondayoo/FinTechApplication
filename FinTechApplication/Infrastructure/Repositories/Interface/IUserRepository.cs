using FinTechApplication.Models;

namespace FinTechApplication.Infrastructure.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<AppUser> SaveUserAsync(AppUser user);
        Task<AppUser> GetUserByIdAsync(string userId);
        Task<AppUser> GetUserByEmailAsync(string userEmail);
    }
}
