using System.Collections.Generic;
using Pegov.Nasvyazi.Application.Buisness.Accounts.Queries.Models;

namespace Pegov.Nasvyazi.Application.Buisness.Organization.Queries.Models
{
    public class OrganizationDto
    {
        public string Name { get; private set; }
        public string Inn { get; private set; }
        public string Kpp { get; private set; }
        public IEnumerable<AccountDto> Accounts { get; private set; }
    }
}