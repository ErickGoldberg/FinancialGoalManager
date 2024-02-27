using FinancialGoalManager.Infrastructure.Persistence;
using MediatR;

namespace FinancialGoalManager.Application.Commands.Transaction.SendTransaction
{
    public class SendTransactionCommandHandler : IRequestHandler<SendTransactionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SendTransactionCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;
        
        public async Task<bool> Handle(SendTransactionCommand command, CancellationToken cancellationToken)
        {
            var financialGoal = await _unitOfWork.FinancialGoalRepository.GetGoalsById(command.IdFinancialGoal);

            if (financialGoal == null)
                return false;

            var transaction = new Core.Entities.Transaction(command.Amount,
                                              command.TransactionType,
                                              command.TransactionDate,
                                              command.IdFinancialGoal,
                                              financialGoal);

            await _unitOfWork.BeginTransactionAsync();
            await _unitOfWork.TransactionRepository.SendTransactionAsync(transaction);
            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}