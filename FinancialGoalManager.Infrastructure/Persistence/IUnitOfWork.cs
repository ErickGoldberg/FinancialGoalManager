using FinancialGoalManager.Core.Repositories;

namespace FinancialGoalManager.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        IFinancialGoalRepository FinancialGoalRepository { get; }
        IReportsRepository ReportsRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task<int> CompleteAsync();
    }
}