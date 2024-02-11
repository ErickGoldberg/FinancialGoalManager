using FinancialGoalManager.Core.Repositories;
using MediatR;

namespace FinancialGoalManager.Application.Queries.FinancialGoal.ListGoals
{
    public class ListGoalsCommandHandler : IRequestHandler<ListGoalsCommand, List<>>
    {
        private readonly IFinancialGoalRepository _financialGoalRepository;

        public ListGoalsCommandHandler(IFinancialGoalRepository financialGoalRepository)
        {
            _financialGoalRepository = financialGoalRepository;
        }


    }
}
