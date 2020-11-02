using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pegov.Nasvyazi.Domains.Entities.Positions;

namespace Pegov.Nasvyazi.Persistence.Postgres.Configurations
{
    public class AccountPositionConfiguration : IEntityTypeConfiguration<AccountPosition>
    {
        public void Configure(EntityTypeBuilder<AccountPosition> builder)
        {
            builder
                .HasKey(t => new { t.AccountId, t.PositionId });
            
            builder
                .HasOne(pt => pt.Account)
                .WithMany(p => p.Positions)
                .HasForeignKey(pt => pt.AccountId);

            builder
                .HasOne(pt => pt.Position)
                .WithMany(t => t.Accounts)
                .HasForeignKey(pt => pt.PositionId);
        }
    }
}