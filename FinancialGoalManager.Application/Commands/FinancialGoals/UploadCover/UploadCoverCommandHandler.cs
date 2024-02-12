using FinancialGoalManager.Core.Repositories;
using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.UploadCover
{
    public class UploadCoverCommandHandler : IRequestHandler<UploadCoverCommand>
    {
        private readonly IFinancialGoalRepository _goalRepository;
        public UploadCoverCommandHandler(IFinancialGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task Handle(UploadCoverCommand request, CancellationToken cancellationToken)
        {
            var goal = await _goalRepository.GetGoalsById(request.Id);

            //if (goal == null)
            //    BadRequest();

            goal.Cover = request.Cover;

            await _goalRepository.UpdateGoal(goal);
        }
    }
}
