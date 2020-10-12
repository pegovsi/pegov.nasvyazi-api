using System;
using System.Collections.Generic;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Entities.Accounts;
using Pegov.Nasvyazi.Domains.Entities.Chats;
using Pegov.Nasvyazi.Domains.Enumerations;

namespace Pegov.Nasvyazi.Domains.Entities.Groups
{
    public class Group : Entity
    {
        protected Group()
        {
            Id = Guid.NewGuid();
            _chats = new List<Chat>();
            _groupTypeId = GroupType.System.Id;
        }

        public Group(string name, Guid accountId, GroupType groupType) 
            : this()
        {
            Name = name;
            AccountId = accountId;
            _groupTypeId = groupType.Id;
        }

        public Guid AccountId { get; protected set; }
        public Account Account { get; protected set; }
        
        public string Name { get; protected set; }
        
        private List<Chat> _chats;
        public IReadOnlyCollection<Chat> Chats => _chats;

        private int _groupTypeId;
        public GroupType GroupType { get; protected set; }

        public void AddChat(Guid chatId)
        {
            var chat = new Chat(chatId);
            _chats.Add(chat);
        }
        public void AddChat(IEnumerable<Guid> chatIds)
        {
            foreach (var chatId in chatIds)
            {
                var chat = new Chat(chatId);
                _chats.Add(chat);   
            }
        }
    }
}