using MediatR;
using Pegov.Nasvyazi.Application.Buisness.Accounts.Queries.Models;

namespace Pegov.Nasvyazi.Application.Buisness.Accounts.Queries.GetAccountById
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