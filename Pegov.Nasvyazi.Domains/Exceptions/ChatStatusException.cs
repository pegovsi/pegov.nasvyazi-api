using System;

namespace Pegov.Nasvyazi.Domains.Exceptions
{
    public class ChatStatusException : Exception
    {
        public ChatStatusException()
        {
            
        }
        public ChatStatusException(string message)
            : base(message)
        {
        }

        public ChatStatusException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}