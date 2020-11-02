using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pegov.Nasvyazi.Domains.Enumerations;

namespace Pegov.Nasvyazi.Persistence.Postgres.Configurations
{
    public class ChatStatusConfiguration : IEntityTypeConfiguration<ChatStatus>
    {
        public void Configure(EntityTypeBuilder<ChatStatus> builder)
        {
            builder
                .ToTable(nameof(ChatStatus));

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