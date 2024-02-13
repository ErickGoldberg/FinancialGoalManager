using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.DeleteGoal
{
    public class DeleteGoalCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
