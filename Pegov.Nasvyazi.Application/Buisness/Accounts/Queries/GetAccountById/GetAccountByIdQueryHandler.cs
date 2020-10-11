using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Pegov.Nasvyazi.Application;
using Pegov.Nasvyazi.Application.Buisness.Accounts.Queries.Models;
using Pegov.Nasvyazi.Application.Common.Interfaces;
using Pegov.Nasvyazi.Application.Infrastructure;
using Pegov.Nasvyazi.Common;


namespace Pegov.Nasvyazi.Application.Buisness.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQueryHandler : HandlerBase<GetAccountByIdQuery, AccountDto>
    {
        public GetAccountByIdQueryHandler(IAppDbContext context, IRavenStore store, ICurrentUserService currentUserService, IMapper mapper)
            : base(context, store, currentUserService, mapper)
        {
        }

        public override async Task<AccountDto> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            // var account = await session.LoadAsync<Account>(request.AccountId, cancellationToken);
            //
            // var organizationIds = account.OrganizationIds.ToArray();
            //
            //
            // var organizations = await (from o in session.Query<pegov.Nasvyazi.Domains.Entities.Organizations.Organization>()
            //         where o.Id.In(organizationIds)
            //         select o
            //     ).ToArrayAsync(cancellationToken);
            //
            // var accountDto = Mapper.Map<AccountDto>(account);
            // var organizationDtos = Mapper.Map<IEnumerable<OrganizationDto>>(organizations);
            // accountDto.Organizations = organizationDtos;
            // return accountDto;
            return null;
        }
    }
}