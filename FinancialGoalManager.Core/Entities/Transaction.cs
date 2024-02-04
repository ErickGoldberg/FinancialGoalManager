using FinancialGoalManager.Core.Enums;

namespace FinancialGoalManager.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
