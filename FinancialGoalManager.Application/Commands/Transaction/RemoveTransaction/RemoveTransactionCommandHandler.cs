using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Repositories;
using MediatR;

namespace FinancialGoalManager.Application.Commands.Transaction.RemoveTransaction
{
    public class RemoveTransactionCommandHandler : IRequestHandler<RemoveTransactionCommand, bool>
    {
        private readonly ITransactionRepository _transactionRepository;

        public RemoveTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<bool> Handle(RemoveTransactionCommand command, CancellationToken cancellationToken)
        {
            var transactionDto = await _transactionRepository.GetTransactionById(command.Id);

            if (transactionDto == null)
                return false;

            var transaction = new Transaction(transactionDto.Amount,
                                              transactionDto.TransactionType,
                                              transactionDto.TransactionDate);

            await _transactionRepository.RemoveTransaction(transaction);

            return true;
        }
    }
}
