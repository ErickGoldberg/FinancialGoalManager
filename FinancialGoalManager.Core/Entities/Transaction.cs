using FinancialGoalManager.Core.Enums;

namespace FinancialGoalManager.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public Transaction(decimal amount, TransactionTypeEnum transactionType, DateTime transactionDate)
        {
            Amount = amount;
            TransactionType = transactionType;
            TransactionDate = transactionDate; // Qual dos 2
            TransactionDate = DateTime.UtcNow; //

            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        public decimal Amount { get; private set; }
        public TransactionTypeEnum TransactionType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime TransactionDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
