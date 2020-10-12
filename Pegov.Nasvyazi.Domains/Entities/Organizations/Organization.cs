using System;
using System.Collections.Generic;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Enumerations;

namespace Pegov.Nasvyazi.Domains.Entities.Organizations
{
    public class Organization : Entity, IAggregateRoot
    {
        protected Organization()
        {
            Id = Guid.NewGuid();
            _entityStatusId = EntityStatus.Active.Id;
            _accountOrganizations = new List<AccountOrganization>();
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

        private readonly List<AccountOrganization> _accountOrganizations;
        public IReadOnlyCollection<AccountOrganization> Accounts => _accountOrganizations;

        private int _entityStatusId;
        public EntityStatus EntityStatus { get; protected set; }

        public void AddAccount(Guid accountId)
        {
            var organization = new AccountOrganization
            {
                AccountId = accountId,
                OrganizationId = Id
            };
            _accountOrganizations.Add(organization);
        }
        public void AddAccount(IEnumerable<Guid> accountIds)
        {
            foreach (var accountId in accountIds)
            {
                var organization = new AccountOrganization
                {
                    AccountId = accountId,
                    OrganizationId = Id
                };
                _accountOrganizations.Add(organization);   
            }
        }
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