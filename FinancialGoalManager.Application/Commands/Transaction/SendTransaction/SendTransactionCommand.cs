using FinancialGoalManager.Core.Enums;
using MediatR;

namespace FinancialGoalManager.Application.Commands.Transaction.SendTransaction
{
    public class SendTransactionCommand : IRequest<bool>
    {
        public decimal Amount { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public int IdFinancialGoal { get; set; }
    }
}