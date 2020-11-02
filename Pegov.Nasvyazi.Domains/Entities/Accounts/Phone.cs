using System.Collections.Generic;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Exceptions;

namespace Pegov.Nasvyazi.Domains.Entities.Accounts
{
    public class Phone : ValueObject
    {
        private Phone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentNotValidException(nameof(phone));
                
            Number = phone;
        }
        public static Phone Create(string phone) => new Phone(phone);

        public string Number { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Number;
        }
    }
}