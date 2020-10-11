using System;

namespace Pegov.Nasvyazi.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string key, string entity)
            :base($"not found entity {entity} by key {key} ")
        {
            
        }
    }
}