using System;
using Pegov.Nasvyazi.Domains.Entities.Accounts;

namespace Pegov.Nasvyazi.Domains.Entities.Organizations
{
    public class AccountOrganization
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}