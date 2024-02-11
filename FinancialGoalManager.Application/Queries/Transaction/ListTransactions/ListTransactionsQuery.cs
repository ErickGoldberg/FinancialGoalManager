using FinancialGoalManager.Core.DTOs;
using MediatR;

namespace FinancialGoalManager.Application.Queries.Transaction.ListTransactions
{
    public class ListTransactionsQuery : IRequest<List<TransactionDto>>
    {
        // Ignore
    }
}
