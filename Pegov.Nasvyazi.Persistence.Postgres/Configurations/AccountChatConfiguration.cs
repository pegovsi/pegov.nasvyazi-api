using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pegov.Nasvyazi.Domains.Entities.Chats;

namespace Pegov.Nasvyazi.Persistence.Postgres.Configurations
{
    public class AccountChatConfiguration : IEntityTypeConfiguration<AccountChat>
    {
        public void Configure(EntityTypeBuilder<AccountChat> builder)
        {
            builder
                .HasKey(t => new { t.AccountId, t.ChatId });

            builder
                .HasOne(pt => pt.Account)
                .WithMany(p => p.Chats)
                .HasForeignKey(pt => pt.AccountId);

            builder
                .HasOne(pt => pt.Chat)
                .WithMany(t => t.AccountChats)
                .HasForeignKey(pt => pt.ChatId);
        }
    }
}