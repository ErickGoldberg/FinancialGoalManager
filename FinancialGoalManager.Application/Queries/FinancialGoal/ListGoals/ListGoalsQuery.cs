using FinancialGoalManager.Core.DTOs;
using MediatR;

namespace FinancialGoalManager.Application.Queries.FinancialGoalQueries.ListGoals
{
    public class ListGoalsQuery : IRequest<List<FinancialGoalDto>>
    {
        // Ignore
    }
}
