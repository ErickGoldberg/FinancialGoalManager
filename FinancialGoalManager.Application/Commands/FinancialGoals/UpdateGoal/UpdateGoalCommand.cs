﻿using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Enums;
using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.UpdateGoal
{
    public class UpdateGoalCommand : BaseEntity, IRequest<bool>
    {
        public string? Title { get; set; }
        public decimal? GoalAmount { get; set; }
        public DateTime? Deadline { get; set; }
        public FinancialGoalStatusEnum? Status { get; set; }
        public byte[]? Cover { get; set; }
    }
}
