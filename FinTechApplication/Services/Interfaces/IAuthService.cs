using FinTechApplication.Models.DTO;
using FinTechApplication.Models;

namespace FinTechApplication.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AppUser> ValidateUser(UserLoginDTO loginDTO);
    }
}
