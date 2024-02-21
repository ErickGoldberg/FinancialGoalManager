using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.DeleteGoal
{
    public class DeleteGoalCommand : IRequest<bool>
    {
        public DeleteGoalCommand(int id) => Id = id;

        public int Id { get; private set; }
    }
}