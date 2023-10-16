using FinTechApplication.Infrastructure.Repositories.Interface;

namespace FinTechApplication.Infrastructure
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IAccountRepository AccountRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task CommitAsync();
    }
}
