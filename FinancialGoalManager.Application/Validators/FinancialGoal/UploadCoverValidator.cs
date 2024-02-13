using FinancialGoalManager.Application.Commands.FinancialGoals.UploadCover;
using FluentValidation;

namespace FinancialGoalManager.Application.Validators.FinancialGoal
{
    public class UploadCoverValidator : AbstractValidator<UploadCoverCommand>
    {
        public UploadCoverValidator()
        {
            RuleFor(i => i.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id is mandatory!");

            RuleFor(i => i.Cover)
                .NotNull()
                .NotEmpty()
                .WithMessage("Cover is mandatory!");
        }
    }
}
