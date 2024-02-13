using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Repositories;
using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.DeleteGoal
{
    public class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand, bool>
    {
        private readonly IFinancialGoalRepository _goalRepository;
        public DeleteGoalCommandHandler(IFinancialGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task<bool> Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
        {
            var financialGoalDto = await _goalRepository.GetGoalsById(request.Id);

            if (financialGoalDto == null)
                return false;

            await _goalRepository.DeleteGoal(financialGoalDto);

            return true;
        }
    }
}
