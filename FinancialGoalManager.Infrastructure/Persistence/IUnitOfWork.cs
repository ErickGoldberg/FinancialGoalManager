using FinancialGoalManager.Core.Repositories;

namespace FinancialGoalManager.Infrastructure.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IFinancialGoalRepository FinancialGoalRepository { get; }
        IReportsRepository ReportsRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task<int> CompleteAsync();
    }
}