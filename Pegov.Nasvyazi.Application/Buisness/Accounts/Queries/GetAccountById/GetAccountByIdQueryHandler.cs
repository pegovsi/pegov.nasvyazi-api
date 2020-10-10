using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Pegov.Nasvayzi.Application.Buisness.Accounts.Queries.Models;
using Pegov.Nasvayzi.Application.Buisness.Organization.Queries.Models;
using Pegov.Nasvayzi.Application.Infrastructure;
using Pegov.Nasvayzi.Common;
using pegov.nasvayzi.Domains.Entities.Accounts;
using Pegov.Nasvyazi.Application;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;


namespace Pegov.Nasvayzi.Application.Buisness.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQueryHandler : HandlerBase<GetAccountByIdQuery, AccountDto>
    {
        public GetAccountByIdQueryHandler(IRavenStore store, ICurrentUserService currentUserService, IMapper mapper) 
            : base(store, currentUserService, mapper)
        {
        }

        public override async Task<AccountDto> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var store = Store.Create();
            using var session = store.OpenAsyncSession();

            var account = await session.LoadAsync<Account>(request.AccountId, cancellationToken);
            
            var organizationIds = account.OrganizationIds.ToArray();
            
            
            var organizations = await (from o in session.Query<pegov.nasvayzi.Domains.Entities.Organizations.Organization>()
                    where o.Id.In(organizationIds)
                    select o
                ).ToArrayAsync(cancellationToken);
            
            var accountDto = Mapper.Map<AccountDto>(account);
            var organizationDtos = Mapper.Map<IEnumerable<OrganizationDto>>(organizations);
            accountDto.Organizations = organizationDtos;
            return accountDto;
        }
    }
}