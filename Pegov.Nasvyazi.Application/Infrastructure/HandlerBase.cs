using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

using Pegov.Nasvyazi.Application.Common.Interfaces;
using Pegov.Nasvyazi.Common;

namespace Pegov.Nasvyazi.Application.Infrastructure
{
    public abstract class HandlerBase<TQ, TM> : IRequestHandler<TQ, TM>
        where TQ : IRequest<TM>
    {
        protected IAppDbContext DbContext { get; private set; }
        protected IRavenStore Store { get; private set; }
        protected ICurrentUserService CurrentUserService { get; private set; }
        protected IMapper Mapper { get; private set; }

        protected HandlerBase(IAppDbContext context, IRavenStore store, ICurrentUserService currentUserService, IMapper mapper)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
            Store = store ?? throw new ArgumentNullException(nameof(store));
            CurrentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public abstract Task<TM> Handle(TQ request, CancellationToken cancellationToken);
    }
}