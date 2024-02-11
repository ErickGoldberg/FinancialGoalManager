using FinancialGoalManager.Application.Commands.RemoveTransaction;
using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Repositories;

namespace FinancialGoalManager.Infrastructure.Persistence.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        // Add D.I do database

        public TransactionRepository()
        {
            // context
        }

        public Task<TransactionDto> GetTransactionById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionDto>> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<List<Transaction>> GetTransactionsDetails()
        {
            throw new NotImplementedException();
        }

        public Task RemoveTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task SendTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
