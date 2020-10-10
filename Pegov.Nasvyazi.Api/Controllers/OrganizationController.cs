using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pegov.Nasvayzi.Application.Buisness.Organization.Commands.CreateOrganization;
using Pegov.Nasvayzi.Application.Buisness.Organization.Queries.GetOrganizationsPages;
using Pegov.Nasvayzi.Common;

namespace Pegov.Nasvayzi.Api.Controllers
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