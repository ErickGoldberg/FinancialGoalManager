using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Entities;

namespace FinancialGoalManager.Core.Repositories
{
    public interface ITransactionRepository
    {
        Task SendTransaction(Transaction transaction);
        Task RemoveTransaction(Transaction transaction);
        Task<List<TransactionDto>> GetTransactions();
        Task<List<Transaction>> GetTransactionsDetails();
        Task<Transaction> GetTransactionById(int Id);
    }
}