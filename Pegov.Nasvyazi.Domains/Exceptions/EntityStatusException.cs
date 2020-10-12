using System;

namespace Pegov.Nasvyazi.Domains.Exceptions
{
    public class EntityStatusException : Exception
    {
        public EntityStatusException()
        {
            
        }
        
        public EntityStatusException(string message)
            : base(message)
        {
        }

        public EntityStatusException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}