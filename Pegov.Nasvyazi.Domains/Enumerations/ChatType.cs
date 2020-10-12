using System;
using System.Collections.Generic;
using System.Linq;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Exceptions;

namespace Pegov.Nasvyazi.Domains.Enumerations
{
    public class ChatType : Enumeration
    {
        protected ChatType(int id, string name) 
            : base(id, name)
        {
        }
        
        public static ChatType Personal = new ChatType(1, nameof(Personal).ToLowerInvariant());
        public static ChatType Group = new ChatType(2, nameof(Group).ToLowerInvariant());
        public static ChatType Channel = new ChatType(3, nameof(Channel).ToLowerInvariant());
        public static ChatType Bot = new ChatType(3, nameof(Bot).ToLowerInvariant());

        private static IEnumerable<ChatType> List() =>
            new[] { Personal, Group, Channel, Bot };

        public static ChatType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new ChatTypeException($"Possible values for {nameof(ChatType)}: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static ChatType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new ChatTypeException($"Possible values for {nameof(ChatType)}: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}