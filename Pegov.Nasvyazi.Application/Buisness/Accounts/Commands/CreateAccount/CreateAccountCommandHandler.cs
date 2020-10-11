using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Pegov.Nasvyazi.Domains.Entities.Accounts;
using Pegov.Nasvyazi.Application.Common.Interfaces;
using Pegov.Nasvyazi.Application.Infrastructure;
using Pegov.Nasvyazi.Common;

namespace Pegov.Nasvyazi.Application.Buisness.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : HandlerBase<CreateAccountCommand, Result<Guid>>
    {
        public CreateAccountCommandHandler(IAppDbContext context, IRavenStore store, ICurrentUserService currentUserService, IMapper mapper)
            : base(context, store, currentUserService, mapper)
        {
        }

        public override async Task<Result<Guid>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account(request.FirstName, request.LastName, request.Email, request.Phone);
            
            // var organization = await session.
            //     Query<pegov.Nasvyazi.Domains.Entities.Organizations.Organization>()
            //     .FirstOrDefaultAsync(x => x.Id == request.OrganizationId.ToString(), cancellationToken);
            
            
            account.AddOrganization(request.OrganizationIds);
            await DbContext.Set<Account>().AddAsync(account, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);

            return ResultHelper.Success(account.Id);
        }
    }
}