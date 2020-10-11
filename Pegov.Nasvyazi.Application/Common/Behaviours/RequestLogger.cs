using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Pegov.Nasvyazi.Common;

namespace Pegov.Nasvyazi.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;

        public RequestLogger(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _currentUserService = currentUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var currentUser = _currentUserService.GetCurrentUser();
            var name = typeof(TRequest).Name;

            _logger.LogInformation(
                "ProjectManagement Request: {Name} {@Request} user: {User}", name, request, currentUser.Login);

            return Task.CompletedTask;
        }
    }
}
