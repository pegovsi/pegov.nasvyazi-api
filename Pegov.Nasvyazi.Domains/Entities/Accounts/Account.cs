using System;
using System.Collections.Generic;
using Pegov.Nasvyazi.Domains.Entities.Organizations;
using Pegov.Nasvyazi.Domains.Common;

namespace Pegov.Nasvyazi.Domains.Entities.Accounts
{
    public class Account : Entity, IAggregateRoot
    {
        protected Account()
        {
            Id = Guid.NewGuid();
            _organizations = new List<Organization>();
        }

        public Account(string firstName, string lastName, string email, string phone)
            :this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = new EmailValueObject(email);
            Phone = new PhoneValueObject(phone);
        }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public EmailValueObject Email { get; protected set; }
        public PhoneValueObject Phone { get; protected set; }

        private readonly List<Organization> _organizations;
        public IReadOnlyCollection<Organization> Organization => _organizations;


        public void AddOrganization(Guid organizationId)
        {
            var organization = new Organization(organizationId);
            _organizations.Add(organization);
        }
        public void AddOrganization(IEnumerable<Guid> organizationIds)
        {
            foreach (var organizationId in organizationIds)
            {
                var organization = new Organization(organizationId);
                _organizations.Add(organization);   
            }
        }
    }
}