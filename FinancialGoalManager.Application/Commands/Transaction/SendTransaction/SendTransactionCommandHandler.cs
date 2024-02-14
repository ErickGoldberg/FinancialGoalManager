using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Infrastructure.Persistence;
using MediatR;

namespace FinancialGoalManager.Application.Commands.Transaction.SendTransaction
{
    public class SendTransactionCommandHandler : IRequestHandler<SendTransactionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SendTransactionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(SendTransactionCommand command, CancellationToken cancellationToken)
        {
            var transaction = new Transactions(command.Amount,
                                              command.TransactionType,
                                              command.TransactionDate);

            await _unitOfWork.TransactionRepository.SendTransaction(transaction);
            await _unitOfWork.CompleteAsync();
        }
    }
}
