using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoalManager.Infrastructure.Persistence.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly FinancialGoalManagerDbContext _context;

        public ReportsRepository(FinancialGoalManagerDbContext context)
            => _context = context;

        public async Task<List<ReportsDto>> GetReports()
        {
            var query = await _context.FinancialGoals
                .Include(i => i.Transactions)
                .Select(reports => new ReportsDto
                {
                    Title = reports.Title,
                    Transactions = reports.Transactions,
                    CreatedAt = reports.CreatedAt,
                    GoalAmount = reports.GoalAmount
                }).ToListAsync();

            return query;
        }
    }
}