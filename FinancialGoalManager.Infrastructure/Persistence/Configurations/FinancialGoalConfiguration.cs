using FinancialGoalManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialGoalManager.Infrastructure.Persistence.Configurations
{
    public class FinancialGoalConfiguration : IEntityTypeConfiguration<FinancialGoal>
    {
        public void Configure(EntityTypeBuilder<FinancialGoal> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasMany(u => u.Transactions)
                   .WithOne(l => l.FinancialGoal)
                   .HasForeignKey(l => l.IdFinancialGoal)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}