using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.SimulateFinancialEvolution
{
    public class SimulateFinancialEvolutionCommand : IRequest<string>
    {
        public int Months { get; set; }
        public double MonthlyIncome { get; set; }
        public double Amount { get; set; }
    }
}
