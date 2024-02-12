using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Repositories;
using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.UpdateGoal
{
    public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand>
    {
        private readonly IFinancialGoalRepository _goalRepository;
        public UpdateGoalCommandHandler(IFinancialGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
        {
            FinancialGoal financialGoal = await _goalRepository.GetGoalsById(request.Id);

            //if (financialGoal == null) 
                //

            if(!string.IsNullOrWhiteSpace(request.Title))
                financialGoal.Title = request.Title;

            if(request.Deadline != null && request.Deadline != DateTime.MinValue)
                financialGoal.Deadline = request.Deadline;

            if(request.Status != null)
                financialGoal.Status = (Core.Enums.FinancialGoalStatusEnum)request.Status;

            if(request.Cover != null)
                financialGoal.Cover = request.Cover;

            await _goalRepository.UpdateGoal(financialGoal);
        }
    }
}
