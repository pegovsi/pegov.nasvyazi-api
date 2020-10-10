using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Pegov.Nasvayzi.Common;
using Pegov.Nasvyazi.Application;

namespace Pegov.Nasvayzi.Application.Infrastructure
{
    public abstract class HandlerBase<TQ, TM> : IRequestHandler<TQ, TM>
        where TQ : IRequest<TM>
    {
        protected IRavenStore Store { get; private set; }
        protected ICurrentUserService CurrentUserService { get; private set; }
        protected IMapper Mapper { get; private set; }

        protected HandlerBase(IRavenStore store, ICurrentUserService currentUserService, IMapper mapper)
        {
            Store = store ?? throw new ArgumentNullException(nameof(store));
            CurrentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public abstract Task<TM> Handle(TQ request, CancellationToken cancellationToken);
    }
}