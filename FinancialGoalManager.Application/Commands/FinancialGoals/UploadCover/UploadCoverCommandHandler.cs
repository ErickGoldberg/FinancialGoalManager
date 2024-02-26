using FinancialGoalManager.Infrastructure.Persistence;
using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.UploadCover
{
    public class UploadCoverCommandHandler : IRequestHandler<UploadCoverCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UploadCoverCommandHandler(IUnitOfWork unitOfWork)
            =>_unitOfWork = unitOfWork;
        
        public async Task<bool> Handle(UploadCoverCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var goal = await _unitOfWork.FinancialGoalRepository.GetGoalsById(request.Id);

            if (goal == null)
                return false;

            using (var stream = new MemoryStream())
            {
                await request.Cover.CopyToAsync(stream);
                var file = stream.ToArray();

                goal.Cover = file;
            }

            await _unitOfWork.FinancialGoalRepository.UpdateGoal(goal);
            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}