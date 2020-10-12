using System;

namespace Pegov.Nasvyazi.Domains.Exceptions
{
    public class GroupTypeException : Exception
    {
        public GroupTypeException()
        {
            
        }
        public GroupTypeException(string message)
            : base(message)
        {
        }

        public GroupTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}