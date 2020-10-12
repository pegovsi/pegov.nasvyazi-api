using System;
using Pegov.Nasvyazi.Domains.Entities.Accounts;

namespace Pegov.Nasvyazi.Domains.Entities.Chats
{
    public class AccountChat
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        public Guid ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}