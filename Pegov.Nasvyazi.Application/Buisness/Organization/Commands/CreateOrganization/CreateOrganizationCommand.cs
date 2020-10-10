using System;
using MediatR;
using Pegov.Nasvayzi.Common;

namespace Pegov.Nasvayzi.Application.Buisness.Organization.Commands.CreateOrganization
{
    public class CreateOrganizationCommand : IRequest<Result<Guid>>
    {
        public CreateOrganizationCommand(string name, string inn, string kpp)
        {
            Name = name;
            Inn = inn;
            Kpp = kpp;
        }

        public string Name { get; private set; }
        public string Inn { get; private set; }
        public string Kpp { get; private set; }
    }
}