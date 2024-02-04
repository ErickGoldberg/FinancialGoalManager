using FinancialGoalManager.Core.Enums;


namespace FinancialGoalManager.Core.Entities
{
    public class FinanancialGoal : BaseEntity
    {
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
