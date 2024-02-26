using FinancialGoalManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinancialGoalManager.Core.Entities
{
    public class FinancialGoal : BaseEntity
    {
        private FinancialGoal() { }
        public FinancialGoal(string title, decimal goalAmount, DateTime? deadline)
        {
            Title = title;
            GoalAmount = goalAmount;

            if (deadline != null)
                Deadline = deadline.Value.Date;

            Status = FinancialGoalStatusEnum.InProgress;
            CreatedAt = DateTime.UtcNow.Date;
            IsDeleted = false;

            if (Deadline != null)
            {
                var timeLeft = deadline - CreatedAt;
                var days = timeLeft.Value.Days;

                var idealMonthlySaving = (GoalAmount / days) * 30;
                IdealMonthlySaving = Math.Round(idealMonthlySaving, 2);
            }
        }

        public string Title { get; set; }
        public decimal GoalAmount { get; private set; }
        public DateTime? Deadline { get; set; }
        public FinancialGoalStatusEnum Status { get; set; }
        public List<Transaction> Transactions { get; set; }
        public byte[]? Cover { get; set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; set; }
        public decimal? IdealMonthlySaving { get; set; }
    }
}