using FinTechApplication.Models;

namespace FinTechApplication.Services.Interface
{
    public interface IUserService
    {
        Task<AppUser> CreateUserAsync(AppUser user);
        Task<AppUser> UpdateUserAsync(AppUser user);
        Task<AppUser> DeleteUserAsync(string userId);
    }
}
