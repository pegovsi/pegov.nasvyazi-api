using System.Collections.Generic;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Exceptions;

namespace Pegov.Nasvyazi.Domains.Entities.Accounts
{
    public class Email : ValueObject
    {
        private Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNotValidException(nameof(email));
            
            Address = email;
        }
        public static Email Create(string email) => new Email(email);

        public string Address { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Address;
        }
    }
}