using FinancialGoalManager.Core.DTOs;
using FinancialGoalManager.Core.Entities;
using FinancialGoalManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoalManager.Infrastructure.Persistence.Repositories
{
    public class FinancialGoalRepository : IFinancialGoalRepository
    {
        private readonly FinancialGoalManagerDbContext _context;

        public FinancialGoalRepository(FinancialGoalManagerDbContext context)
            => _context = context;

        public async Task<List<FinancialGoalDto>> ListGoals()
        {
            var financialGoals = await _context.FinancialGoals.Select(goal => new FinancialGoalDto
            {
                Title = goal.Title,
                GoalAmount = goal.GoalAmount,
                Status = goal.Status
            }).ToListAsync() ?? new List<FinancialGoalDto>();

            return financialGoals;
        }

        public async Task<FinancialGoal> GetGoalsById(int id)
           => await _context.FinancialGoals.SingleOrDefaultAsync(i => i.Id == id);

        public async Task DeleteGoal(FinancialGoal financialGoal)
            => _context.FinancialGoals.Remove(financialGoal);

        public async Task<List<FinancialGoal>> GetGoalsDetails()
            => await _context.FinancialGoals.ToListAsync();

        public async Task RegisterGoal(FinancialGoal financialGoal)
            => await _context.FinancialGoals.AddAsync(financialGoal);

        public async Task UpdateGoal(FinancialGoal financialGoal)
            => _context.FinancialGoals.Update(financialGoal);
    }
}