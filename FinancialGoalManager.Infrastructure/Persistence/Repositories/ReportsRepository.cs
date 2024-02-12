using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Repositories;

namespace FinancialGoalManager.Infrastructure.Persistence.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        // Add D.I do database

        public ReportsRepository()
        {
            // context
        }

        public async Task<List<ReportsDto>> GetReports()
        {
            
            return new List<ReportsDto>();
        }
    }
}
