using FinancialGoalManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoalManager.Infrastructure.Persistence
{
    public class FinancialGoalManagerDbContext : DbContext
    {
        public FinancialGoalManagerDbContext(DbContextOptions<FinancialGoalManagerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<FinancialGoal> FinancialGoals { get; set; }
    }
}
