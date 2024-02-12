using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.DeleteGoal
{
    public class DeleteGoalCommand : IRequest
    {
        public int Id { get; set; }
    }
}
