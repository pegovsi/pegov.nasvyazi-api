using System;
using Pegov.Nasvyazi.Raven.Domains.Common;

namespace Pegov.Nasvyazi.Raven.Domains.Entities
{
    public sealed class PinnedMessage : Entity
    {
        private PinnedMessage()
        {
            Id = base.NewGuidString();
        }

        public PinnedMessage(string chatId, string messageId, string authorId)
        {
            ChatId = chatId;
            MessageId = messageId;
            AuthorId = authorId;
            PinnedDate = DateTime.UtcNow;
        }
        public string ChatId { get; }
        public string MessageId { get; }
        public string AuthorId { get; }
        public DateTime PinnedDate { get; }
    }
}