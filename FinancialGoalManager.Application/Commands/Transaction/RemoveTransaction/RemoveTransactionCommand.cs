using MediatR;

namespace FinancialGoalManager.Application.Commands.Transaction.RemoveTransaction
{
    public class RemoveTransactionCommand : IRequest<bool>
    {
        public RemoveTransactionCommand(int id) => Id = id;

        public int Id { get; private set; }
    }
}