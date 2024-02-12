using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Entities;

namespace FinancialGoalManager.Core.Repositories
{
    public interface ITransactionRepository
    {
        Task SendTransaction(Transactions transaction);
        Task RemoveTransaction(Transactions transaction);
        Task<List<TransactionDto>> GetTransactions();
        Task<List<Transactions>> GetTransactionsDetails();
        Task<TransactionDto> GetTransactionById(int Id);
    }
}
