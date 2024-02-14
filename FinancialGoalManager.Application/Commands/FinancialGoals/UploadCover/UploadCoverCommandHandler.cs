using FinancialGoalManager.Infrastructure.Persistence;
using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.UploadCover
{
    public class UploadCoverCommandHandler : IRequestHandler<UploadCoverCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UploadCoverCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UploadCoverCommand request, CancellationToken cancellationToken)
        {
            var goal = await _unitOfWork.FinancialGoalRepository.GetGoalsById(request.Id);

            if (goal == null)
                return false;

            goal.Cover = request.Cover;

            await _unitOfWork.FinancialGoalRepository.UpdateGoal(goal);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}