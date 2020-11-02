using System.Collections.Generic;
using Pegov.Nasvyazi.Domains.Common;

namespace Pegov.Nasvyazi.Domains.Entities.Accounts
{
    public class Email : ValueObject
    {
        private Email()
        {
        }

        public Email(string email)
        {
            //здксь логика проверки, регулярки и т.д.
            Address = email;
        }

        public string Address { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Address;
        }
    }
}