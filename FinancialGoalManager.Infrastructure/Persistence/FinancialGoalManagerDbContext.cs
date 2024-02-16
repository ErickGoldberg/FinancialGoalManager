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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinancialGoal>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Transaction>()
                .HasKey(i => i.Id);


            modelBuilder.Entity<FinancialGoal>()
                .HasMany(u => u.Transactions)
                .WithOne(l => l.FinancialGoal)
                .HasForeignKey(l => l.IdFinancialGoal)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}