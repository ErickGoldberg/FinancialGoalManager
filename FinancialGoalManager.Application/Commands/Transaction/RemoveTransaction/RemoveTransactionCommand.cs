using MediatR;

namespace FinancialGoalManager.Application.Commands.Transaction.RemoveTransaction
{
    public class RemoveTransactionCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
