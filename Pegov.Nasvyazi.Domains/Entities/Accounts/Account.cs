using System;
using System.Collections;
using System.Collections.Generic;
using pegov.nasvayzi.Domains.Common;
using pegov.nasvayzi.Domains.Entities.Organizations;

namespace pegov.nasvayzi.Domains.Entities.Accounts
{
    public class Account : Entity, IAggregateRoot
    {
        protected Account()
        {
            Id = NewGuidString();
            OrganizationIds = new HashSet<string>();
        }

        public Account(string firstName, string lastName, string email, string phone)
            :this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }


        public override string Id { get; protected set; }
        
        public string FirstName { get; protected set; }
        public string LastName { get; private set; }
        public string Email { get; protected set; }
        public string Phone { get; protected set; }

        public ICollection<string> OrganizationIds { get; protected set; }


        public void AddOrganization(string organizationId)
        {
            OrganizationIds.Add(organizationId);
        }
        public void AddOrganization(IEnumerable<Guid> organizationIds)
        {
            foreach (var organizationId in organizationIds)
            {
                OrganizationIds.Add(organizationId.ToString());   
            }
        }
    }
}