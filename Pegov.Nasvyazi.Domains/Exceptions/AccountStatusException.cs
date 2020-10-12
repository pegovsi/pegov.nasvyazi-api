using System;

namespace Pegov.Nasvyazi.Domains.Exceptions
{
    public class AccountStatusException : Exception
    {
        public AccountStatusException()
        {
            
        }
        public AccountStatusException(string message)
            : base(message)
        {
        }

        public AccountStatusException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}