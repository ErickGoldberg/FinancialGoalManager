using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Entities;

namespace FinancialGoalManager.Core.Repositories
{
    public interface IFinancialGoalRepository
    {
        Task RegisterGoal(FinancialGoal financialGoal);
        Task UpdateGoal(FinancialGoal financialGoal);
        Task DeleteGoal(FinancialGoal financialGoal);
        Task<FinancialGoal> GetGoalsById(int id);
        Task<List<FinancialGoalDto>> ListGoals();
        Task<List<FinancialGoal>> GetGoalsDetails();
    }
}
