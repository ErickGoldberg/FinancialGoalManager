using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoalManager.Infrastructure.Persistence.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FinancialGoalManagerDbContext _context;

        public TransactionRepository(FinancialGoalManagerDbContext context)
            => _context = context;

        public async Task<List<TransactionDto>> GetTransactionsAsync()
        {
            var transactions = await _context.Transactions.Select(transaction => new TransactionDto
            {
                Amount = transaction.Amount,
                TransactionType = transaction.TransactionType,
                TransactionDate = transaction.TransactionDate
            }).ToListAsync() ?? new List<TransactionDto>(); 

            return transactions;
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
            => await _context.Transactions.SingleOrDefaultAsync(i => i.Id == id);

        public async Task<List<Transaction>> GetTransactionsDetailsAsync()
            => await _context.Transactions.ToListAsync();

        public async Task RemoveTransaction(Transaction transaction)
            => _context.Transactions.Remove(transaction);
        
        public async Task SendTransactionAsync(Transaction transaction)
            => await _context.Transactions.AddAsync(transaction);
    }
}