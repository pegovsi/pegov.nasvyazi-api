using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pegov.Nasvyazi.Application.Buisness.Organization.Commands.CreateOrganization;
using Pegov.Nasvyazi.Application.Buisness.Organization.Queries.GetOrganizationsPages;
using Pegov.Nasvyazi.Common;

namespace Pegov.Nasvyazi.Api.Controllers
{
    [Route("api/v{version:apiVersion}/organization")]
    [ApiVersion(VersionController.Version1_0)]
    public class OrganizationController : BaseController
    {
        [HttpPost]
        public async Task<Result<Guid>> CreateOrganization(
            [FromBody] CreateOrganizationCommand command, CancellationToken token)
            => await Mediator.Send(command, token);

        [HttpGet]
        public async Task<OrganizationViewModel> GetOrganizationPages(CancellationToken token)
            => await Mediator.Send(new GetOrganizationsPagesQuery(), token);
    }
}