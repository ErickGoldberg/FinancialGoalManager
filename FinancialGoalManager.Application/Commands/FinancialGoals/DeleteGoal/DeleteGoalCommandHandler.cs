using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Repositories;
using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.DeleteGoal
{
    public class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand>
    {
        private readonly IFinancialGoalRepository _goalRepository;
        public DeleteGoalCommandHandler(IFinancialGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
        {
            var financialGoalDto = await _goalRepository.GetGoalsById(request.Id);

            await _goalRepository.DeleteGoal(financialGoalDto);
        }
    }
}
