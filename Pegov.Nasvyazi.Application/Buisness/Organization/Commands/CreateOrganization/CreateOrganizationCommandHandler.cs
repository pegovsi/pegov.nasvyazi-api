using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Pegov.Nasvyazi.Application.Common.Interfaces;
using Pegov.Nasvyazi.Application.Infrastructure;
using Pegov.Nasvyazi.Common;

namespace Pegov.Nasvyazi.Application.Buisness.Organization.Commands.CreateOrganization
{
    public class CreateOrganizationCommandHandler: HandlerBase<CreateOrganizationCommand, Result<Guid>>
    {
        public CreateOrganizationCommandHandler(IAppDbContext context, IRavenStore store, ICurrentUserService currentUserService, IMapper mapper)
            : base(context, store, currentUserService, mapper)
        {
        }

        public override async Task<Result<Guid>> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = new Nasvyazi.Domains.Entities.Organizations.Organization(request.Name, request.Inn, request.Kpp);
            
            
            await DbContext.Set<Nasvyazi.Domains.Entities.Organizations.Organization>()
                .AddAsync(organization, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);
            
            return ResultHelper.Success(organization.Id);
        }
    }
}