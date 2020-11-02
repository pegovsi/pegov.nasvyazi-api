using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pegov.Nasvyazi.Domains.Entities.Organizations;

namespace Pegov.Nasvyazi.Persistence.Postgres.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organizations");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            
            builder.Property(e => e.Inn)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnType("varchar(12)");
            
            builder.Property(e => e.Kpp)
                .IsRequired()
                .HasMaxLength(9)
                .HasColumnType("varchar(9)");
            //
            // builder.HasMany(x => x.Accounts)
            //     .WithOne(x => x.Organization);
            // var navigation = builder
            //     .Metadata
            //     .FindNavigation(nameof(Organization.Accounts));
            // navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .Property<int>("_entityStatusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("EntityStatusId")
                .IsRequired();

            builder
                .HasOne(o => o.EntityStatus)
                .WithMany()
                .HasForeignKey("_entityStatusId");
            
            
            builder.HasIndex(e => e.Name);
        }
    }
}