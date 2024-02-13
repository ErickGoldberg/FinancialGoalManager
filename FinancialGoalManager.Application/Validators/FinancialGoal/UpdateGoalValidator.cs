using FinancialGoalManager.Application.Commands.FinancialGoals.UpdateGoal;
using FinancialGoalManager.Application.Validators.Helper;
using FluentValidation;

namespace FinancialGoalManager.Application.Validators.FinancialGoal
{
    public class UpdateGoalValidator : AbstractValidator<UpdateGoalCommand>
    {
        public UpdateGoalValidator()
        {
            RuleFor(i => i.Title)
                .Must(ValidatorsHelper.ValidateTitle)
                .WithMessage("Title must have 3-30 characters!");

            RuleFor(i => i.GoalAmount)
                .Must(ValidatorsHelper.ValidateGoalAmount)
                .WithMessage("The Goal Amount must be at least 500 and 1.000.000!");

            RuleFor(i => i.Deadline)
                .Must(ValidatorsHelper.ValidateDeadLine)
                .WithMessage("The deadline must have at least 2 months and the maximum date 5 years!");

            RuleFor(i => i.Status)
                .Must(ValidatorsHelper.ValidateStatus)
                .WithMessage("Be sure that you have passed a valid enum!");
        }
    }
}