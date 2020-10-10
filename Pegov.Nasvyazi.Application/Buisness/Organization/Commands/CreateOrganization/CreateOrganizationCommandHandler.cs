using System;
using System.Threading;
using System.Threading.Tasks;
using Pegov.Nasvayzi.Application.Infrastructure;
using Pegov.Nasvayzi.Common;
using Pegov.Nasvyazi.Application;

namespace Pegov.Nasvayzi.Application.Buisness.Organization.Commands.CreateOrganization
{
    public class CreateOrganizationCommandHandler: HandlerBase<CreateOrganizationCommand, Result<Guid>>
    {
        public CreateOrganizationCommandHandler(IRavenStore store, ICurrentUserService currentUserService) 
            : base(store, currentUserService)
        {
        }

        public override async Task<Result<Guid>> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            return ResultHelper.Success(Guid.NewGuid());

        }
    }
}