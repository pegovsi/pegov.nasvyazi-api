using MediatR;
using Pegov.Nasvayzi.Application.Buisness.Accounts.Queries.Models;

namespace Pegov.Nasvayzi.Application.Buisness.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQuery : IRequest<AccountDto>
    {
        public GetAccountByIdQuery(string accountId)
        {
            AccountId = accountId;
        }

        public string AccountId { get; }
    }
}