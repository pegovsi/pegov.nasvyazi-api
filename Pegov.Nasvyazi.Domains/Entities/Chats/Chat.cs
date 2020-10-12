using System;
using System.Collections.Generic;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Enumerations;
using Pegov.Nasvyazi.Domains.Exceptions;

namespace Pegov.Nasvyazi.Domains.Entities.Chats
{
    public class Chat : Entity
    {
        protected Chat()
        {
            Id = Guid.NewGuid();
            _chatTypeId = ChatType.Personal.Id;
            _chatStatusId = ChatStatus.Active.Id;
            _accountChats = new List<AccountChat>();
        }

        public Chat(ChatType chatType)
            : this()
        {
            _chatTypeId = chatType.Id;
        }

        public Chat(Guid chatId)
        {
            Id = chatId;
        }

        public string Name { get; protected set; }
        public string Logo { get; protected set; }

        private int _chatStatusId;
        public ChatStatus ChatStatus { get; protected set; }

        private List<AccountChat> _accountChats;
        public IReadOnlyCollection<AccountChat> AccountChats => _accountChats;

        private readonly int _chatTypeId;
        public ChatType ChatType { get; protected set; }

        
        public void SetName(string name)
        {
            if(_chatTypeId == ChatType.Personal.Id 
               || _chatTypeId == ChatType.Bot.Id)
                return;
            
            if (string.IsNullOrEmpty(name))
                throw new ChatStatusException(nameof(name));
            
            Name = name;
        }

        public void SetLogo(string logo)
        {
            Logo = logo;
        }


        public void AddAccount(Guid accountId)
        {
            var accountChat = new AccountChat
            {
                AccountId = accountId,
                ChatId = Id
            };
            _accountChats.Add(accountChat);
        }
        public void AddAccount(IEnumerable<Guid> accountIds)
        {
            foreach (var accountId in accountIds)
            {
                var accountChat = new AccountChat
                {
                    AccountId = accountId,
                    ChatId = Id
                };
                _accountChats.Add(accountChat); 
            }
        }
    }
}