using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Repositories;
using MediatR;

namespace FinancialGoalManager.Application.Queries.FinancialGoalQueries.GetGoalsDetails
{
    public class GetGoalsDetailsQueryHandler : IRequestHandler<GetGoalsDetailsQuery, List<FinancialGoal>>
    {
        private readonly IFinancialGoalRepository _goalRepository;
        public GetGoalsDetailsQueryHandler(IFinancialGoalRepository goalRepository)
            => _goalRepository = goalRepository;
        
        public async Task<List<FinancialGoal>> Handle(GetGoalsDetailsQuery request, CancellationToken cancellationToken)
            => await _goalRepository.GetGoalsDetails();
    }
}