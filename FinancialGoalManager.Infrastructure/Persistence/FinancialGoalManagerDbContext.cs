using FinancialGoalManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoalManager.Infrastructure.Persistence
{
    public class FinancialGoalManagerDbContext : DbContext
    {
        public FinancialGoalManagerDbContext(DbContextOptions<FinancialGoalManagerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<FinancialGoal> FinancialGoals { get; set; }
    }
}
