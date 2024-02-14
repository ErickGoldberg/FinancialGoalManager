using FinancialGoalManager.Core.Repositories;

namespace FinancialGoalManager.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
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