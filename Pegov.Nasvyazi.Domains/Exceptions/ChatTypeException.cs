using System;

namespace Pegov.Nasvyazi.Domains.Exceptions
{
    public class ChatTypeException : Exception
    {
        public ChatTypeException()
        {
            
        }
        public ChatTypeException(string message)
            : base(message)
        {
        }

        public ChatTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}