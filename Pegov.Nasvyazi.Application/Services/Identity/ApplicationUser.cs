using System;
using System.Collections.Generic;

namespace Pegov.Nasvyazi.Application.Services.Identity
{
    public class ApplicationUser
    {
        public ApplicationUser()
        {
            Roles = new HashSet<ApplicationRole>();
        }

        public Guid AccountId { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsConfirm { get; set; }
        public ICollection<ApplicationRole> Roles { get; set; }
    }
    
    public class ApplicationRole
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Mnemonic { get; set; }
    }
}