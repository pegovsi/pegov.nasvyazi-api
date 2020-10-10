using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Pegov.Nasvayzi.Application.Buisness.Organization.Queries.Models;
using Pegov.Nasvayzi.Application.Infrastructure;
using Pegov.Nasvayzi.Common;
using Pegov.Nasvyazi.Application;
using Raven.Client.Documents;

namespace Pegov.Nasvayzi.Application.Buisness.Organization.Queries.GetOrganizationsPages
{
    public class GetOrganizationsPagesQueryHandler : HandlerBase<GetOrganizationsPagesQuery, OrganizationViewModel>
    {
        public GetOrganizationsPagesQueryHandler(IRavenStore store, ICurrentUserService currentUserService, IMapper mapper)
            : base(store, currentUserService, mapper)
        {
        }

        public override async Task<OrganizationViewModel> Handle(GetOrganizationsPagesQuery request, CancellationToken cancellationToken)
        {
            var store = Store.Create();
            using var session = store.OpenAsyncSession();
            var organizations = await session
                .Query<pegov.nasvayzi.Domains.Entities.Organizations.Organization>()
                .ToArrayAsync(cancellationToken);
            return new OrganizationViewModel
            {
                Data = Mapper.Map<IEnumerable<OrganizationDto>>(organizations),
                TotalCount = organizations.Length
            };
        }
    }
}