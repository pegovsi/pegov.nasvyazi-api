using System;
using System.Collections.Generic;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Entities.Accounts;

namespace Pegov.Nasvyazi.Domains.Entities.Organizations
{
    public class Organization : Entity, IAggregateRoot
    {
        protected Organization()
        {
            Id = Guid.NewGuid();
            _accounts = new List<Account>();
        }

        public Organization(string name, string inn, string kpp)
            :this()
        {
            Name = name;
            Inn = inn;
            Kpp = kpp;
        }

        public Organization(Guid organizationId)
        {
            Id = organizationId;
        }

        public string Name { get; protected set; }
        public string Inn { get; protected set; }
        public string Kpp { get; protected set; }

        private readonly List<Account> _accounts;
        public IReadOnlyCollection<Account> Accounts => _accounts;
    }
}