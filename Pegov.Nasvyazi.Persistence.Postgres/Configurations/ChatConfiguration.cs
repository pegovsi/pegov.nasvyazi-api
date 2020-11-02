using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pegov.Nasvyazi.Domains.Entities.Chats;

namespace Pegov.Nasvyazi.Persistence.Postgres.Configurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable("Chats");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            
            var navigationAccounts = builder
                .Metadata
                .FindNavigation(nameof(Chat.AccountChats));
            navigationAccounts.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .HasMany(e => e.AccountChats)
                .WithOne();

            builder
                .Property<int>("_chatStatusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ChatStatusId")
                .IsRequired();

            builder
                .HasOne(o => o.ChatStatus)
                .WithMany()
                .HasForeignKey("_chatStatusId");
            
            builder.HasIndex(x => x.Name);
        }
    }
}