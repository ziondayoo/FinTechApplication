using FinTechApplication.Models.DTO;
using FinTechApplication.Models;

namespace FinTechApplication.Services.Interface
{
    public interface IAuthService
    {
        Task<AppUser> ValidateUser(UserLoginDTO loginDTO);
    }
}
