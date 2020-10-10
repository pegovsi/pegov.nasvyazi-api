using System.Collections.Generic;
using Pegov.Nasvayzi.Application.Buisness.Organization.Queries.Models;

namespace Pegov.Nasvayzi.Application.Buisness.Accounts.Queries.Models
{
    public class AccountDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IEnumerable<OrganizationDto> Organizations { get; set; }
    }
}