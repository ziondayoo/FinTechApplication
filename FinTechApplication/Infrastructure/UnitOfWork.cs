using FinTechApplication.Infrastructure.Database;
using FinTechApplication.Infrastructure.Repositories.Interface;

namespace FinTechApplication.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => throw new NotImplementedException();

        public IAccountRepository AccountRepository => throw new NotImplementedException();

        public ITransactionRepository TransactionRepository => throw new NotImplementedException();

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
