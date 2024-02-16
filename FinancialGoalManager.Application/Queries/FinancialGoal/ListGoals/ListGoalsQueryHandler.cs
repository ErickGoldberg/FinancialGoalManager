using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Repositories;
using MediatR;

namespace FinancialGoalManager.Application.Queries.FinancialGoalQueries.ListGoals
{
    public class ListGoalsQueryHandler : IRequestHandler<ListGoalsQuery, List<FinancialGoalDto>>
    {
        private readonly IFinancialGoalRepository _financialGoalRepository;

        public ListGoalsQueryHandler(IFinancialGoalRepository financialGoalRepository)
            => _financialGoalRepository = financialGoalRepository;
        
        public async Task<List<FinancialGoalDto>> Handle(ListGoalsQuery request, CancellationToken cancellationToken)
            =>  await _financialGoalRepository.ListGoals();
    }
}