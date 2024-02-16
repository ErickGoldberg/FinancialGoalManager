using FinancialGoalManager.Core.DTOs;
using MediatR;

namespace FinancialGoalManager.Application.Queries.Reports.GetReports
{
    public class GetReportsQuery : IRequest<List<ReportsDto>>
    {
        // Ignore
    }
}