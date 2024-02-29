using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Entities;

namespace FinancialGoalManager.Core.Repositories
{
    public interface ITransactionRepository
    {
        Task SendTransactionAsync(Transaction transaction, FinancialGoal financialGoal);
        Task RemoveTransaction(Transaction transaction);
        Task<List<TransactionDto>> GetTransactionsAsync();
        Task<List<Transaction>> GetTransactionsDetailsAsync();
        Task<Transaction> GetTransactionByIdAsync(int Id);
    }
}