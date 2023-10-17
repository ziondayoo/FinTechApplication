using FinTechApplication.Infrastructure.Database;
using FinTechApplication.Infrastructure.Repositories.Interface;

namespace FinTechApplication.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        public IUserRepository UserRepository { get; }

        public IAccountRepository AccountRepository { get; }

        public ITransactionRepository TransactionRepository { get; }



        public UnitOfWork(AppDbContext context, IUserRepository userRepository, IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _context = context;
            UserRepository = userRepository;
            AccountRepository = accountRepository;
            TransactionRepository = transactionRepository;

        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
