using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Pegov.Nasvyazi.Application.Common.Interfaces;
using Pegov.Nasvyazi.Application.Infrastructure;
using Pegov.Nasvyazi.Common;

namespace Pegov.Nasvyazi.Application.Buisness.Message.Commands.SaveMessage
{
    public class SaveMessageCommandCommandHandler : CommandHandler<SaveMessageCommand, Result<Guid>>
    {
        public SaveMessageCommandCommandHandler(IAppDbContext context, IRavenStore store, ICurrentUserService currentUserService, IMapper mapper) 
            : base(context, store, currentUserService, mapper)
        {
        }

        public override async Task<Result<Guid>> Handle(SaveMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Nasvyazi.Raven.Domains.Entities.Message
            (
                request.ChatId.ToString(),
                request.AuthorId.ToString(),
                request.Content,
                request.MessageTypeId.ToString()
            );

            var store = Store.Create();
            using var session = store.OpenAsyncSession();

            await session.StoreAsync(message, cancellationToken);
            await session.SaveChangesAsync(cancellationToken);

            return ResultHelper.Success(Guid.Empty);
        }
    }
}