using FinancialGoalManager.Core.Enums;

namespace FinancialGoalManager.Core.Entities
{
    public class FinancialGoal : BaseEntity
    {
        private FinancialGoal() { }
        public FinancialGoal(string title, decimal goalAmount, FinancialGoalStatusEnum status, DateTime? deadline)
        {
            Title = title;  
            GoalAmount = goalAmount;
            Status = status;
            Deadline = deadline;

            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;

            if (Deadline != null)
            {
                var timeLeft = deadline - CreatedAt;
                var days = timeLeft.Value.Days;

                IdealMonthlySaving = (GoalAmount / days) * 30;
            }
        }

        public string Title { get; set; }
        public decimal GoalAmount { get; private set; }
        public DateTime? Deadline { get; set; }
        public decimal? IdealMonthlySaving { get; set; }
        public FinancialGoalStatusEnum Status { get; set; }
        public List<Transaction> Transactions { get; set; }
        public byte[]? Cover { get; set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; set; }
    }
}