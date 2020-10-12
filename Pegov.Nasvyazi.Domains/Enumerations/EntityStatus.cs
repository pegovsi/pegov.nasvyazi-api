using System;
using System.Collections.Generic;
using System.Linq;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Exceptions;

namespace Pegov.Nasvyazi.Domains.Enumerations
{
    public class EntityStatus : Enumeration
    {
        protected EntityStatus(int id, string name) 
            : base(id, name)
        {
        }
        
        public static EntityStatus Active = new EntityStatus(1, nameof(Active).ToLowerInvariant());
        public static EntityStatus Deleted = new EntityStatus(2, nameof(Deleted).ToLowerInvariant());

        private static IEnumerable<EntityStatus> List() =>
            new[] { Active, Deleted };

        public static EntityStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new EntityStatusException($"Possible values for {nameof(ChatStatus)}: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static EntityStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new EntityStatusException($"Possible values for {nameof(ChatStatus)}: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}