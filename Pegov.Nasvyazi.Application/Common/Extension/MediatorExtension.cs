using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pegov.Nasvyazi.Domains.Common;

namespace Pegov.Nasvyazi.Application.Common.Extension
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(
            this IMediator mediator, IEnumerable<EntityEntry<Entity>> entityEntries)
        {
            var enumerable = entityEntries as EntityEntry<Entity>[] ?? entityEntries.ToArray();
            var domainEvents = enumerable
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }

            enumerable.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());
        }
    }
}