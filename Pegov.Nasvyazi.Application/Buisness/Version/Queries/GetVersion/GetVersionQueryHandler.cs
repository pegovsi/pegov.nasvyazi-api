using System.Threading;
using System.Threading.Tasks;
using Pegov.Nasvayzi.Application.Infrastructure;
using Pegov.Nasvayzi.Common;
using Pegov.Nasvyazi.Application;

namespace Pegov.Nasvayzi.Application.Buisness.Version.Queries.GetVersion
{
    public class GetVersionQueryHandler : HandlerBase<GetVersionQuery, string>
    {
        public GetVersionQueryHandler(IRavenStore store, ICurrentUserService currentUserService)
            : base(store, currentUserService)
        {
        }

        public override async Task<string> Handle(GetVersionQuery request, CancellationToken cancellationToken)
        {
            var version = "Messenger NaSvyazi version 1";
            return await Task.FromResult(version);
        }
    }
}