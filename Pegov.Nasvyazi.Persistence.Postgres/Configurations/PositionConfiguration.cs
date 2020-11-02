using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pegov.Nasvyazi.Domains.Entities.Positions;

namespace Pegov.Nasvyazi.Persistence.Postgres.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            
            var navigation = builder
                .Metadata
                .FindNavigation(nameof(Position.Accounts));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .HasMany(e => e.Accounts)
                .WithOne();

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