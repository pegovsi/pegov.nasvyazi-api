using Pegov.Nasvyazi.Raven.Domains.Common;

namespace Pegov.Nasvyazi.Raven.Domains.Entities
{
    public class MessageType : Entity
    {
        protected MessageType()
        {
            Id = base.NewGuidString();
        }

        public MessageType(string name, string mnemonic)
        {
            Name = name;
            Mnemonic = mnemonic;
        }

        public string Name { get; protected set; }
        public string Mnemonic { get; protected set; }
    }
}