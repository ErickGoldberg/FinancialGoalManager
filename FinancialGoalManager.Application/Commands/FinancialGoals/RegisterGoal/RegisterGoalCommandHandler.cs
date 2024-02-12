using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Repositories;
using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.RegisterGoal
{
    public class RegisterGoalCommandHandler : IRequestHandler<RegisterGoalCommand>
    {
        private readonly IFinancialGoalRepository _goalRepository;
        public RegisterGoalCommandHandler(IFinancialGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task Handle(RegisterGoalCommand request, CancellationToken cancellationToken)
        {
            var command = new FinancialGoal(request.Title, request.GoalAmount, request.Status, request.Deadline);

            await _goalRepository.RegisterGoal(command);
        }
    }
}
