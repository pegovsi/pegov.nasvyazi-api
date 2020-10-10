using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Pegov.Nasvayzi.Application.Infrastructure;
using Pegov.Nasvayzi.Common;
using pegov.nasvayzi.Domains.Entities.Accounts;
using Pegov.Nasvyazi.Application;
using Raven.Client.Documents;

namespace Pegov.Nasvayzi.Application.Buisness.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : HandlerBase<CreateAccountCommand, Result<Guid>>
    {
        public CreateAccountCommandHandler(IRavenStore store, ICurrentUserService currentUserService, IMapper mapper)
            : base(store, currentUserService, mapper)
        {
        }

        public override async Task<Result<Guid>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account(request.FirstName, request.LastName, request.Email, request.Phone);
            
            var store = Store.Create();
            using var session = store.OpenAsyncSession();

            // var organization = await session.
            //     Query<pegov.nasvayzi.Domains.Entities.Organizations.Organization>()
            //     .FirstOrDefaultAsync(x => x.Id == request.OrganizationId.ToString(), cancellationToken);
            
            
            account.AddOrganization(request.OrganizationIds);
            await session.StoreAsync(account, cancellationToken);
            await session.SaveChangesAsync(cancellationToken);

            return ResultHelper.Success(account.GetId());
        }
    }
}