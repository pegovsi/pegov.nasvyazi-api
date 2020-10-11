using System;
using MediatR;
using Pegov.Nasvyazi.Common;

namespace Pegov.Nasvyazi.Application.Buisness.Message.Commands.SaveMessage
{
    public class SaveMessageCommand : IRequest<Result<Guid>>
    {
        public Guid ChatId { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public Guid MessageTypeId { get; set; }
    }
}