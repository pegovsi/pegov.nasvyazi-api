using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pegov.Nasvyazi.Domains.Entities.Organizations;

namespace Pegov.Nasvyazi.Persistence.Postgres.Configurations
{
    public class AccountOrganizationConfiguration : IEntityTypeConfiguration<AccountOrganization>
    {
        public void Configure(EntityTypeBuilder<AccountOrganization> builder)
        {
            builder
                .HasKey(t => new { t.AccountId, t.OrganizationId });
            
            builder
                .HasOne(pt => pt.Account)
                .WithMany(p => p.Organizations)
                .HasForeignKey(pt => pt.AccountId);

            builder
                .HasOne(pt => pt.Organization)
                .WithMany(t => t.Accounts)
                .HasForeignKey(pt => pt.OrganizationId);
        }
    }
}