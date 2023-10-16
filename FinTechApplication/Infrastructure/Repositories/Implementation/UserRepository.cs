using FinTechApplication.Infrastructure.Database;
using FinTechApplication.Infrastructure.Repositories.Interface;
using FinTechApplication.Models;

namespace FinTechApplication.Infrastructure.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _ctx;

        public UserRepository(AppDbContext dbContext)
        {
            _ctx = dbContext;
        }
        public Task<AppUser> GetUserByEmailAsync(string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> SaveUserAsync(AppUser user)
        {
            await _ctx.Users.AddAsync(user);
            return user;
        }
    }
}
