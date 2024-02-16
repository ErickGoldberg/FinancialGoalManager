using FinancialGoalManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinancialGoalManager.Infrastructure.Persistence
{
    public class FinancialGoalManagerDbContext : DbContext
    {
        public FinancialGoalManagerDbContext(DbContextOptions<FinancialGoalManagerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<FinancialGoal> FinancialGoals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}