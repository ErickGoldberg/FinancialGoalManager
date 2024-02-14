using FinancialGoalManager.Infrastructure.Persistence;
using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.DeleteGoal
{
    public class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGoalCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
        {
            var financialGoalDto = await _unitOfWork.FinancialGoalRepository.GetGoalsById(request.Id);

            if (financialGoalDto == null)
                return false;

            await _unitOfWork.FinancialGoalRepository.DeleteGoal(financialGoalDto);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}