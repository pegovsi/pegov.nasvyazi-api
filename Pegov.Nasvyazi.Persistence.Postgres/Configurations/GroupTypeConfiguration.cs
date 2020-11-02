using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pegov.Nasvyazi.Domains.Enumerations;

namespace Pegov.Nasvyazi.Persistence.Postgres.Configurations
{
    public class GroupTypeConfiguration : IEntityTypeConfiguration<GroupType>
    {
        public void Configure(EntityTypeBuilder<GroupType> builder)
        {
            builder
                .ToTable(nameof(GroupType));

            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}