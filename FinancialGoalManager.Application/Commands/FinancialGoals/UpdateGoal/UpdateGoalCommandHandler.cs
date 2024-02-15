using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Repositories;
using FinancialGoalManager.Infrastructure.Persistence;
using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.UpdateGoal
{
    public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGoalCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var financialGoal = await _unitOfWork.FinancialGoalRepository.GetGoalsById(request.Id);

            if (financialGoal == null)
                return false;

            if (!string.IsNullOrWhiteSpace(request.Title))
                financialGoal.Title = request.Title;

            if (request.Deadline != null && request.Deadline != DateTime.MinValue)
                financialGoal.Deadline = request.Deadline;

            if (request.Status != null)
                financialGoal.Status = (Core.Enums.FinancialGoalStatusEnum)request.Status;

            if (request.Cover != null)
                financialGoal.Cover = request.Cover;

            await _unitOfWork.FinancialGoalRepository.UpdateGoal(financialGoal);
            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
