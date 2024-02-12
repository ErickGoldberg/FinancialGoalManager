using FinancialGoalManager.Application.Commands.FinancialGoals.RegisterGoal;
using FluentValidation;

namespace FinancialGoalManager.Application.Validators.FinancialGoal
{
    public class RegisterGoalValidator : AbstractValidator<RegisterGoalCommand>
    {
        public RegisterGoalValidator() 
        { 
            
        }
    }
}
