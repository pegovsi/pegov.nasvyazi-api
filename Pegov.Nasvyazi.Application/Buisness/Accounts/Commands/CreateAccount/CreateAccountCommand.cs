using System;
using System.Collections.Generic;
using MediatR;
using Pegov.Nasvyazi.Common;

namespace Pegov.Nasvyazi.Application.Buisness.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<Result<Guid>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IEnumerable<Guid> OrganizationIds { get; set; }
    }
}