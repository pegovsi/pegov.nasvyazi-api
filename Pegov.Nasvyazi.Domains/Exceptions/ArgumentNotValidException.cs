using System;

namespace Pegov.Nasvyazi.Domains.Exceptions
{
    public class ArgumentNotValidException : Exception
    {
        public ArgumentNotValidException(string argument)
            :base(argument)
        {
            
        }
    }
}