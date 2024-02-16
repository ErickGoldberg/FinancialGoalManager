using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Repositories;
using MediatR;

namespace FinancialGoalManager.Application.Queries.Transaction.ListTransactions
{
    public class ListTransactionsQueryHandler : IRequestHandler<ListTransactionsQuery, List<TransactionDto>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public ListTransactionsQueryHandler(ITransactionRepository transactionRepository)
            => _transactionRepository = transactionRepository;
        
        public async Task<List<TransactionDto>> Handle(ListTransactionsQuery request, CancellationToken cancellationToken)
            => await _transactionRepository.GetTransactions();
    }
}