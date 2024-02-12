using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Repositories;
using MediatR;

namespace FinancialGoalManager.Application.Queries.Reports.GetReports
{
    public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, List<ReportsDto>>
    {
        private readonly IReportsRepository _reportsRepository;
        public GetReportsQueryHandler(IReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }

        public async Task<List<ReportsDto>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
        {
            var reports = _reportsRepository.GetReports();

            return await reports;
        }
    }
}
