using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Infrastructure.Persistence;
using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.RegisterGoal
{
    public class RegisterGoalCommandHandler : IRequestHandler<RegisterGoalCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterGoalCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task Handle(RegisterGoalCommand request, CancellationToken cancellationToken)
        {
            var financialGoal = new FinancialGoal(request.Title, request.GoalAmount, request.Deadline);

            await _unitOfWork.BeginTransactionAsync();

            await _unitOfWork.FinancialGoalRepository.RegisterGoalAsync(financialGoal);
            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();
        }
    }
}