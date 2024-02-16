using FinancialGoalManager.Core.Enums;

namespace FinancialGoalManager.Core.DTOs
{
    public class FinancialGoalDto
    {
        public string Title { get; set; }
        public decimal GoalAmount { get; set; }
        public FinancialGoalStatusEnum Status { get; set; }
    }
}
