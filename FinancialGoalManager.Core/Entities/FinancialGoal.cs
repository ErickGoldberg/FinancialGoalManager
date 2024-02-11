using FinancialGoalManager.Core.Enums;

namespace FinancialGoalManager.Core.Entities
{
    public class FinancialGoal : BaseEntity
    {
        private FinancialGoal() { }
        public FinancialGoal(string title, decimal goalAmount, FinancialGoalStatusEnum status)
        {
            Title = title;  
            GoalAmount = goalAmount;
            Status = status;
        }

        public string Title { get; set; }
        public decimal GoalAmount { get; set; }
        public DateTime? Deadline { get; set; }
        public decimal? IdealMonthlySaving { get; set; }
        public FinancialGoalStatusEnum Status { get; set; }
        public List<Transaction> Transactions { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}