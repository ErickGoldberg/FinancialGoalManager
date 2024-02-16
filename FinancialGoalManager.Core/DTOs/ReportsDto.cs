using FinancialGoalManager.Core.Entities;

namespace FinancialGoalManager.Core.DTOs
{
    public class ReportsDto
    {
        public string Title { get; private set; }
        public decimal GoalAmount { get; private set; }
        public DateTime CreatedAt { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
