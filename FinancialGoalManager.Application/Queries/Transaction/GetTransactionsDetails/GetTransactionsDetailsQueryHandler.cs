using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Repositories;
using MediatR;


namespace FinancialGoalManager.Application.Queries.Transaction.GetTransactionsDetails
{
    public class GetTransactionsDetailsQueryHandler : IRequestHandler<GetTransactionsDetailsQuery, List<Transactions>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionsDetailsQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<List<Transactions>> Handle(GetTransactionsDetailsQuery request, CancellationToken cancellationToken)
            => await _transactionRepository.GetTransactionsDetails();
    }
}
