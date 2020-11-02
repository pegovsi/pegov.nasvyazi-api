using System;
using System.Collections.Generic;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Entities.Accounts;
using Pegov.Nasvyazi.Domains.Enumerations;

namespace Pegov.Nasvyazi.Domains.Entities.Positions
{
    public class Position : Entity, IAggregateRoot
    {
        protected Position()
        {
            Id = Guid.NewGuid();
            _entityStatusId = EntityStatus.Active.Id;
            _accountPositions = new List<AccountPosition>();
        }
        public Position(string name) 
            : this()
        {
            Name = name;
        }
        public Position(string name, string description) 
            : this()
        {
            Name = name;
            Description = description;
        }

        public Position(Guid positionId)
        {
            Id = positionId;
        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        
        private int _entityStatusId;
        public EntityStatus EntityStatus { get; protected set; }
        
        private readonly List<AccountPosition> _accountPositions;
        public IReadOnlyCollection<AccountPosition> Accounts => _accountPositions;

        public void Delete()
        {
            _entityStatusId = EntityStatus.Deleted.Id;
        }
        public void Recovery()
        {
            _entityStatusId = EntityStatus.Active.Id;
        }
    }
}