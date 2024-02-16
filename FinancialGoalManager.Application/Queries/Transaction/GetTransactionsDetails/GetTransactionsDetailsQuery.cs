using MediatR;

namespace FinancialGoalManager.Application.Queries.Transaction.GetTransactionsDetails
{
    public class GetTransactionsDetailsQuery : IRequest<List<Core.Entities.Transaction>>
    {
        // Ignore
    }
}