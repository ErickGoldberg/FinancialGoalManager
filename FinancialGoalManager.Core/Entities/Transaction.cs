using FinancialGoalManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinancialGoalManager.Core.Entities
{
    public class Transaction : BaseEntity
    {
        private Transaction() { }
        public Transaction(decimal amount, TransactionTypeEnum transactionType, DateTime transactionDate)
        {
            Amount = amount;
            TransactionType = transactionType;
            TransactionDate = transactionDate;

            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal Amount { get; private set; }
        public TransactionTypeEnum TransactionType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public bool IsDeleted { get; set; }

        public FinancialGoal FinancialGoal { get; set; }
        public int IdFinancialGoal { get; set; }
    }
}