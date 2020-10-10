using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Pegov.Nasvayzi.Application.Infrastructure;
using Pegov.Nasvayzi.Common;
using Pegov.Nasvyazi.Application;

namespace Pegov.Nasvayzi.Application.Buisness.Organization.Commands.CreateOrganization
{
    public class CreateOrganizationCommandHandler: HandlerBase<CreateOrganizationCommand, Result<Guid>>
    {
        public CreateOrganizationCommandHandler(IRavenStore store, ICurrentUserService currentUserService, IMapper mapper) 
            : base(store, currentUserService, mapper)
        {
        }

        public override async Task<Result<Guid>> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = new pegov.nasvayzi.Domains.Entities.Organizations.Organization(request.Name, request.Inn, request.Kpp);
            var id = organization.GetId();
            
            var store = Store.Create();
            using var session = store.OpenAsyncSession();
            await session.StoreAsync(organization, cancellationToken);
            await session.SaveChangesAsync(cancellationToken);
            
            return ResultHelper.Success(id);
        }
    }
}