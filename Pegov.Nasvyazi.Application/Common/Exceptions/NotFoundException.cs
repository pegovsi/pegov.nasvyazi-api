using System;

namespace pegov.nasvayzi.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string key, string entity)
            :base($"not found entity {entity} by key {key} ")
        {
            
        }
    }
}