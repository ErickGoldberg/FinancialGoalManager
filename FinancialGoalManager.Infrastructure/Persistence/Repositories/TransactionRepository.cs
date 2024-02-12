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

        public Task<List<Transactions>> GetTransactionsDetails()
        {
            throw new NotImplementedException();
        }

        public Task RemoveTransaction(Transactions transaction)
        {
            throw new NotImplementedException();
        }

        public Task SendTransaction(Transactions transaction)
        {
            throw new NotImplementedException();
        }
    }
}
