﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Prt.Graphit.Application.Common.Behaviours
{
    public class RequestRolesBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public RequestRolesBehavior()
        {
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            return next();
        }
    }
}