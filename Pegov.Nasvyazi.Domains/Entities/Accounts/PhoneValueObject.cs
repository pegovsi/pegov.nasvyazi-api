using System.Collections.Generic;
using Pegov.Nasvyazi.Domains.Common;

namespace Pegov.Nasvyazi.Domains.Entities.Accounts
{
    public class PhoneValueObject : ValueObject
    {
        private PhoneValueObject()
        {
        }

        public PhoneValueObject(string phone)
        {
            Phone = phone;
        }

        public string Phone { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Phone;
        }
    }
}