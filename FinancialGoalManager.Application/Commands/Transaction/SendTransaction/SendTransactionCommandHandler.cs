using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Repositories;
using MediatR;

namespace FinancialGoalManager.Application.Commands.Transaction.SendTransaction
{
    public class SendTransactionCommandHandler : IRequestHandler<SendTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;

        public SendTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task Handle(SendTransactionCommand command, CancellationToken cancellationToken)
        {
            var transaction = new Core.Entities.Transactions(command.Amount,
                                              command.TransactionType,
                                              command.TransactionDate);

            await _transactionRepository.SendTransaction(transaction);
        }
    }
}
