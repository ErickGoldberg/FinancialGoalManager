using FinancialGoalManager.Core.DTOs;

namespace FinancialGoalManager.Core.Repositories
{
    public interface IReportsRepository
    {
        Task<List<ReportsDto>> GetReports();
    }
}