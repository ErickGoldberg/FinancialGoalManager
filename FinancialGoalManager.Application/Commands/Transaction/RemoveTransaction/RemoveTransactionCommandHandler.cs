using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Infrastructure.Persistence;
using MediatR;

namespace FinancialGoalManager.Application.Commands.Transaction.RemoveTransaction
{
    public class RemoveTransactionCommandHandler : IRequestHandler<RemoveTransactionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveTransactionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(RemoveTransactionCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            var transactionDto = await _unitOfWork.TransactionRepository.GetTransactionById(command.Id);

            if (transactionDto == null)
                return false;

            var transaction = new Transactions(transactionDto.Amount,
                                              transactionDto.TransactionType,
                                              transactionDto.TransactionDate);

            await _unitOfWork.TransactionRepository.RemoveTransaction(transaction);
            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
