using System;
using Pegov.Nasvyazi.Raven.Domains.Common;

namespace Pegov.Nasvyazi.Raven.Domains.Entities
{
    public class Message : Entity
    {
        protected Message()
        {
            Id = base.NewGuidString();
            Created = DateTime.UtcNow;
        }
        
        public Message(string chatId, string authorId, string content, string messageTypeId)
            :this()
        {
            ChatId = chatId;
            AuthorId = authorId;
            MessageTypeId = messageTypeId;
            Content = content;
            File = null;
        }
        
        public Message(string chatId, string authorId, string content, File file, string messageTypeId)
            :this()
        {
            ChatId = chatId;
            AuthorId = authorId;
            MessageTypeId = messageTypeId;
            Content = content;
            File = file;
        }

        #region Property

        public string ChatId { get; protected set; }
        public string AuthorId { get; protected set; }
        public string Content { get; protected set; }
        public DateTime? Edited { get; protected set; }
        public DateTime Created { get; protected set; }
        public bool Read { get; protected set; }
        public bool Delivered { get; protected set; }
        public bool Deleted { get; protected set; }
        public DateTime? DeletedDate { get; protected set; }
        public File File { get; protected set; }
        public string MessageTypeId { get; protected set; }

        #endregion


        #region Logic

        public void ReadMessage()
        {
            Read = true;
        }

        public void DeliveredMessage()
        {
            Delivered = true;
        }

        public void EditedMessage()
        {
            Edited = DateTime.UtcNow;
        }

        public void DeleteMessage()
        {
            Deleted = true;
            DeletedDate = DateTime.UtcNow;
        }

        #endregion
    }

    public class File
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}