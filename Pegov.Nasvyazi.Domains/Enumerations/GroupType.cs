using System;
using System.Collections.Generic;
using System.Linq;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Exceptions;

namespace Pegov.Nasvyazi.Domains.Enumerations
{
    public class GroupType : Enumeration
    {
        protected GroupType(int id, string name) 
            : base(id, name)
        {
        }
        
        public static GroupType System = new GroupType(1, nameof(System).ToLowerInvariant());
        public static GroupType Manual = new GroupType(2, nameof(Manual).ToLowerInvariant());

        private static IEnumerable<GroupType> List() =>
            new[] { System, Manual };

        public static GroupType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new GroupTypeException($"Possible values for {nameof(GroupType)}: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static GroupType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new GroupTypeException($"Possible values for {nameof(GroupType)}: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}