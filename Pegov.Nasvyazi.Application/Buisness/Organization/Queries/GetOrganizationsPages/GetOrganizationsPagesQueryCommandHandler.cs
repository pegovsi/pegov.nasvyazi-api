using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Pegov.Nasvyazi.Application.Buisness.Organization.Queries.Models;
using Pegov.Nasvyazi.Application.Common.Interfaces;
using Pegov.Nasvyazi.Application.Infrastructure;
using Pegov.Nasvyazi.Common;
using Raven.Client.Documents;

namespace Pegov.Nasvyazi.Application.Buisness.Organization.Queries.GetOrganizationsPages
{
    public class GetOrganizationsPagesQueryCommandHandler : CommandHandler<GetOrganizationsPagesQuery, OrganizationViewModel>
    {
        public GetOrganizationsPagesQueryCommandHandler(IAppDbContext context, IRavenStore store, ICurrentUserService currentUserService, IMapper mapper)
            : base(context, store, currentUserService, mapper)
        {
        }

        public override async Task<OrganizationViewModel> Handle(GetOrganizationsPagesQuery request, CancellationToken cancellationToken)
        {
            
            var organizations = await DbContext
                .Set<Nasvyazi.Domains.Entities.Organizations.Organization>()
                .Skip(0)
                .Take(100)
                .ToArrayAsync(cancellationToken);
            
            return new OrganizationViewModel
            {
                Data = Mapper.Map<IEnumerable<OrganizationDto>>(organizations),
                TotalCount = organizations.Length
            };
        }
    }
}