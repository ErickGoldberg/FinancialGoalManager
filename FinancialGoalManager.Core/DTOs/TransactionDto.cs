using FinancialGoalManager.Core.Enums;

namespace FinancialGoalManager.Core.DTOs
{
    public class TransactionDto
    {
        public decimal Amount { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}