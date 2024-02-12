using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Repositories;

namespace FinancialGoalManager.Infrastructure.Persistence.Repositories
{
    public class FinancialGoalRepository : IFinancialGoalRepository
    {
        // Add D.I do database
        public FinancialGoalRepository()
        {
            // context
        }

        public Task DeleteGoal(FinancialGoal financialGoal)
        {
            throw new NotImplementedException();
        }

        public Task<FinancialGoal> GetGoalsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FinancialGoal>> GetGoalsDetails()
        {
            throw new NotImplementedException();
        }

        public Task<List<FinancialGoalDto>> ListGoals()
        {
            throw new NotImplementedException();
        }

        public Task RegisterGoal(FinancialGoal financialGoal)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGoal(FinancialGoal financialGoal)
        {
            throw new NotImplementedException();
        }
    }
}
