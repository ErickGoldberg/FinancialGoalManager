namespace FinancialGoalManager.Core.Repositories
{
    public interface IFinancialGoalRepository
    {
        Task RegisterGoal();
        Task UpdateGoal();
        Task DeleteGoal();
        Task GetGoalsById(int id);
        Task ListGoals();
        Task GetGoalsDetails();
    }
}
