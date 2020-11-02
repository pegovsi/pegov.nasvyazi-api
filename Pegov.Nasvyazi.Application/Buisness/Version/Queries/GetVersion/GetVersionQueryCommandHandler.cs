using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Pegov.Nasvyazi.Application;
using Pegov.Nasvyazi.Application.Common.Interfaces;
using Pegov.Nasvyazi.Application.Infrastructure;
using Pegov.Nasvyazi.Common;

namespace Pegov.Nasvyazi.Application.Buisness.Version.Queries.GetVersion
{
    public class GetVersionQueryCommandHandler : CommandHandler<GetVersionQuery, string>
    {
        public GetVersionQueryCommandHandler(IAppDbContext context, IRavenStore store, ICurrentUserService currentUserService, IMapper mapper)
            : base(context, store, currentUserService, mapper)
        {
        }

        public override async Task<string> Handle(GetVersionQuery request, CancellationToken cancellationToken)
        {
            var version = "Messenger NaSvyazi version 1";
            return await Task.FromResult(version);
        }
    }
}