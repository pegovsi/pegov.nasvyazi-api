using System;
using System.Collections.Generic;
using System.Linq;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Exceptions;

namespace Pegov.Nasvyazi.Domains.Enumerations
{
    public class AccountStatus : Enumeration
    {
        protected AccountStatus(int id, string name) 
            : base(id, name)
        {
        }
        
        public static AccountStatus Active = new AccountStatus(1, nameof(Active).ToLowerInvariant());
        public static AccountStatus Blocked = new AccountStatus(2, nameof(Blocked).ToLowerInvariant());
        public static AccountStatus Deleted = new AccountStatus(3, nameof(Deleted).ToLowerInvariant());

        private static IEnumerable<AccountStatus> List() =>
            new[] { Active, Blocked, Deleted };

        public static AccountStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new AccountStatusException($"Possible values for {nameof(AccountStatus)}: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static AccountStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new AccountStatusException($"Possible values for {nameof(AccountStatus)}: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}