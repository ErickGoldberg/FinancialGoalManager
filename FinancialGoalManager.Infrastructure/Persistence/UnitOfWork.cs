using FinancialGoalManager.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace FinancialGoalManager.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly FinancialGoalManagerDbContext _context;
        public UnitOfWork(FinancialGoalManagerDbContext context,
                          IFinancialGoalRepository financialGoalRepository,
                          IReportsRepository reportsRepository,
                          ITransactionRepository transactionRepository)
        {
            _context = context;
            FinancialGoalRepository = financialGoalRepository;
            ReportsRepository = reportsRepository;
            TransactionRepository = transactionRepository;  
        }

        public IFinancialGoalRepository FinancialGoalRepository { get; }
        public IReportsRepository ReportsRepository { get; }
        public ITransactionRepository TransactionRepository { get; }

        public async Task BeginTransactionAsync()
            => _transaction = await _context.Database.BeginTransactionAsync();
        
        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception)
            {
                await _transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
                _context.Dispose();
        }
    }
}