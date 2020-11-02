using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pegov.Nasvyazi.Domains.Entities.Groups;

namespace Pegov.Nasvyazi.Persistence.Postgres.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");

            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            
            var navigation = builder
                .Metadata
                .FindNavigation(nameof(Group.Chats));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .HasMany(e => e.Chats)
                .WithOne();

            builder
                .Property<int>("_groupTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("GroupTypeId")
                .IsRequired();

            builder
                .HasOne(o => o.GroupType)
                .WithMany()
                .HasForeignKey("_groupTypeId");
            
            builder.HasIndex(e => e.Name);
        }
    }
}