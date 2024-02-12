using FinancialGoalManager.Core.Entities;
using MediatR;

namespace FinancialGoalManager.Application.Queries.FinancialGoalQueries.GetGoalsDetails
{
    public class GetGoalsDetailsQuery : IRequest<List<FinancialGoal>>
    {
        // Ignore
    }
}
