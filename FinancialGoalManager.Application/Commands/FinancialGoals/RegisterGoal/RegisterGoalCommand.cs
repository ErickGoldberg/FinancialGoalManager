using FinancialGoalManager.Core.Enums;
using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.RegisterGoal
{
    public class RegisterGoalCommand : IRequest
    {
        public string Title { get; set; }
        public decimal GoalAmount { get; set; }
        public FinancialGoalStatusEnum Status { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
