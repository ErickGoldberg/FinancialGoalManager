using MediatR;

namespace FinancialGoalManager.Application.Commands.FinancialGoals.SimulateFinancialEvolution
{
    public class SimulateFinancialEvolutionCommandHandler : IRequestHandler<SimulateFinancialEvolutionCommand, string>
    {
        public async Task<string> Handle(SimulateFinancialEvolutionCommand request, CancellationToken cancellationToken)
        {
            var fee = 1 + (request.MonthlyIncome / 100);
            var finalAmount = request.Amount * Math.Pow(fee, request.Months);

            var result = $"The final amount is gonna be: {finalAmount}";

            return result;
        }
    }
}
