using System;
using MediatR;

namespace Pegov.Nasvyazi.Domains.Entities.Accounts.Notifications
{
    public class AccountCreatedDomainEvent : INotification
    {
        public AccountCreatedDomainEvent(Guid accountId)
        {
            AccountId = accountId;
        }
        public Guid AccountId { get; }
    }
}