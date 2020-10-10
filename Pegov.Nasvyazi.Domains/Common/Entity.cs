using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MediatR;
using Newtonsoft.Json;

namespace pegov.nasvayzi.Domains.Common
{
    public class Entity
    {
        [NotMapped]
        [JsonIgnore]
        public bool IsNew { get; set; }
        public virtual string Id { get; protected set; }
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }

        public virtual Guid GetId()
        {
            return string.IsNullOrEmpty(Id) ? Guid.Empty : Guid.Parse(Id);
        }

        public virtual Guid NewGuid()
        {
            return Guid.NewGuid();
        }
        public virtual string NewGuidString()
        {
            return Guid.NewGuid().ToString();
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