using FinancialGoalManager.Application.Commands.Transaction.SendTransaction;
using FluentValidation;

namespace FinancialGoalManager.Application.Validators.Transaction
{
    public class SendTransactionValidator : AbstractValidator<SendTransactionCommand>
    {
        public SendTransactionValidator() 
        {
            RuleFor(i => i.Amount)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(100000)
                .WithMessage("The Amount have to be at least 1 real and the maximum 100.000!");

            RuleFor(i => i.TransactionDate)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(new DateTime(2024, 01, 01))
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("The transaction date must be in the interval of 2024 and the current date!");

            RuleFor(i => i.TransactionType)
                .NotNull()
                .NotEmpty()
                .IsInEnum()
                .WithMessage("Be sure that you have passed a valid enum!");
        }
    }
}