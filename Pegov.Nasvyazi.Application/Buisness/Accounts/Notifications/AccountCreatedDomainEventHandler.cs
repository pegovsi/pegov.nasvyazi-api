using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pegov.Nasvyazi.Application.Common.Interfaces;
using Pegov.Nasvyazi.Domains.Entities.Accounts.Notifications;
using Pegov.Nasvyazi.Domains.Enumerations;
using Group = Pegov.Nasvyazi.Domains.Entities.Groups.Group;

namespace Pegov.Nasvyazi.Application.Buisness.Accounts.Notifications
{
    public class AccountCreatedDomainEventHandler : INotificationHandler<AccountCreatedDomainEvent>
    {
        private readonly IAppDbContext _context;

        public AccountCreatedDomainEventHandler(IAppDbContext context)
        {
            _context = context;
        }
        
        public async Task Handle(AccountCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await CreatGroup(notification, cancellationToken);
        }

        private async Task CreatGroup(AccountCreatedDomainEvent notification, CancellationToken token)
        {
            var group = new Group("Все группы", notification.AccountId, GroupType.System);
            await _context.Set<Group>().AddAsync(group, token);
            await _context.SaveChangesAsync(token);
        }
    }
}