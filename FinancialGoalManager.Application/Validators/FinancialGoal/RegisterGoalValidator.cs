using FinancialGoalManager.Application.Commands.FinancialGoals.RegisterGoal;
using FluentValidation;

namespace FinancialGoalManager.Application.Validators.FinancialGoal
{
    public class RegisterGoalValidator : AbstractValidator<RegisterGoalCommand>
    {
        public RegisterGoalValidator() 
        {
            RuleFor(i => i.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30)
                .WithMessage("Title must have 3-30 characters!");

            RuleFor(i => i.GoalAmount)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(500)
                .LessThanOrEqualTo(1000000)
                .WithMessage("The Goal Amount must be at least 500 and 1.000.000!");

            RuleFor(i => i.Deadline)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now.AddMonths(2))
                .LessThanOrEqualTo(DateTime.Now.AddYears(5))
                .WithMessage("The deadline must have at least 2 months and the maximum date 5 years!");

            RuleFor(i => i.Status)
                .NotNull()
                .NotEmpty()
                .IsInEnum()
                .WithMessage("Be sure that you have passed a valid enum!");
        }
    }
}
