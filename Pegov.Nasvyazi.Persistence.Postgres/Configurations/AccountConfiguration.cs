using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pegov.Nasvyazi.Domains.Entities.Accounts;
using Pegov.Nasvyazi.Domains.Entities.Organizations;

namespace Pegov.Nasvyazi.Persistence.Postgres.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.FirstName)
                .IsRequired(false)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.LastName)
                .IsRequired(false)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            // builder.HasMany(x => x.Organizations)
            //     .WithOne(x => x.Account);
            // var navigationOrganization = builder
            //     .Metadata
            //     .FindNavigation("_accountOrganizations");
            // navigationOrganization.SetPropertyAccessMode(PropertyAccessMode.Field);
            // builder
            //     .Property(e=>e.Organizations)
            //     .HasField("_accountOrganizations")
            //     .UsePropertyAccessMode(PropertyAccessMode.Field);
            
            var navigationGroups = builder
                .Metadata
                .FindNavigation(nameof(Account.Groups));
            navigationGroups.SetPropertyAccessMode(PropertyAccessMode.Field);
            
            var navigationPositions = builder
                .Metadata
                .FindNavigation(nameof(Account.Positions));
            navigationPositions.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .HasMany(e => e.Positions)
                .WithOne();
            
            var navigationChats = builder
                .Metadata
                .FindNavigation(nameof(Account.Chats));
            navigationChats.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .HasMany(e => e.Chats)
                .WithOne();
            
            builder
                .Property<int>("_accountStatusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AccountStatusId")
                .IsRequired();

            builder
                .HasOne(o => o.AccountStatus)
                .WithMany()
                .HasForeignKey("_accountStatusId");

            
            builder.OwnsOne(p => p.Email);
            builder.OwnsOne(p => p.Phone);
        }
    }
}