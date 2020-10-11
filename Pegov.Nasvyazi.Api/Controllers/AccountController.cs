using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pegov.Nasvyazi.Application.Buisness.Accounts.Commands.CreateAccount;
using Pegov.Nasvyazi.Application.Buisness.Accounts.Queries.GetAccountById;
using Pegov.Nasvyazi.Application.Buisness.Accounts.Queries.Models;
using Pegov.Nasvyazi.Common;

namespace Pegov.Nasvyazi.Api.Controllers
{
    [Route("api/v{version:apiVersion}/account")]
    [ApiVersion(VersionController.Version1_0)]
    public class AccountController : BaseController
    {
        [HttpPost]
        public async Task<Result<Guid>> CreateAccount(
            [FromBody] CreateAccountCommand command, CancellationToken token)
            => await Mediator.Send(command, token);

        [HttpGet, Route("{id}")]
        public async Task<AccountDto> GetAccountById(string id, CancellationToken token)
            => await Mediator.Send(new GetAccountByIdQuery(id), token);
    }
}