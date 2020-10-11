using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MediatR;
using Newtonsoft.Json;

namespace Pegov.Nasvyazi.Domains.Common
{
    public class Entity
    {
        [NotMapped]
        [JsonIgnore]
        public bool IsNew { get; set; }
        public virtual Guid Id { get; protected set; }
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }

        public virtual Guid NewGuid()
        {
            return Guid.NewGuid();
        }

        private List<INotification> _domainEvents;

        [NotMapped]
        [JsonIgnore]
        public IReadOnlyCollection<INotification> DomainEvents
            => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}