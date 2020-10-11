using System.Collections.Generic;
using Pegov.Nasvyazi.Domains.Common;

namespace Pegov.Nasvyazi.Domains.Entities.Accounts
{
    public class EmailValueObject : ValueObject
    {
        private EmailValueObject()
        {
        }

        public EmailValueObject(string email)
        {
            //здксь логика проверки, регулярки и т.д.
            Email = email;
        }

        public string Email { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Email;
        }
    }
}