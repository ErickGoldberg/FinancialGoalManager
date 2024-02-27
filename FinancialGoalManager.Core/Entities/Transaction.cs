using FinancialGoalManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinancialGoalManager.Core.Entities
{
    public class Transaction : BaseEntity
    {
        private Transaction() { }
        public Transaction(decimal amount, TransactionTypeEnum transactionType,
            DateTime transactionDate, int idFinancialGoal, FinancialGoal financialGoal)
        {
            Amount = Math.Round(amount, 2);
            TransactionType = transactionType;
            TransactionDate = transactionDate;
            IdFinancialGoal = idFinancialGoal;
            FinancialGoal = financialGoal;

            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        public decimal Amount { get; private set; }
        public TransactionTypeEnum TransactionType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public bool IsDeleted { get; set; }

        public FinancialGoal FinancialGoal { get; set; }
        public int IdFinancialGoal { get; set; }
    }
}