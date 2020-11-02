using System.Collections.Generic;
using Pegov.Nasvyazi.Domains.Common;

namespace Pegov.Nasvyazi.Domains.Entities.Accounts
{
    public class Phone : ValueObject
    {
        private Phone()
        {
        }

        public Phone(string phone)
        {
            Number = phone;
        }

        public string Number { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Number;
        }
    }
}