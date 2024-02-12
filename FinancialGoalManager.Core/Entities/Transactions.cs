using FinancialGoalManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinancialGoalManager.Core.Entities
{
    public class Transactions : BaseEntity
    {
        private Transactions() { }
        public Transactions(decimal amount, TransactionTypeEnum transactionType, DateTime transactionDate)
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
        public DateTime TransactionDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
