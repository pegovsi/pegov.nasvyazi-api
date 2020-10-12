using System;
using System.Collections.Generic;
using System.Linq;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Exceptions;

namespace Pegov.Nasvyazi.Domains.Enumerations
{
    public class ChatStatus : Enumeration
    {
        protected ChatStatus(int id, string name) 
            : base(id, name)
        {
        }
        
        public static ChatStatus Active = new ChatStatus(1, nameof(Active).ToLowerInvariant());
        public static ChatStatus Blocked = new ChatStatus(2, nameof(Blocked).ToLowerInvariant());
        public static ChatStatus Archive = new ChatStatus(3, nameof(Archive).ToLowerInvariant());

        private static IEnumerable<ChatStatus> List() =>
            new[] { Active, Blocked, Archive };

        public static ChatStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new ChatStatusException($"Possible values for {nameof(ChatStatus)}: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static ChatStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new ChatStatusException($"Possible values for {nameof(ChatStatus)}: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}