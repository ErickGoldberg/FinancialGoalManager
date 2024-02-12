using FinancialGoalManager.Core.Enums;

namespace FinancialGoalManager.Core.DTOs
{
    public class FinancialGoalDto
    {
        public string Title { get; private set; }
        public decimal GoalAmount { get; private set; }
        public FinancialGoalStatusEnum Status { get; private set; }
    }
}
