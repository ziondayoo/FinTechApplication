using FinTechApplication.Infrastructure;
using FinTechApplication.Models;
using FinTechApplication.Services.Interface;

namespace FinTechApplication.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AppUser> CreateUserAsync(AppUser user)
        {
            var registeredUser = await _unitOfWork.UserRepository.SaveUserAsync(user);
            await _unitOfWork.CommitAsync();
            return registeredUser;


        }

        public Task<AppUser> DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> UpdateUserAsync(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
