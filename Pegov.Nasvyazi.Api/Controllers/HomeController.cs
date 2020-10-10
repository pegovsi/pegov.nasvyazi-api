using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pegov.Nasvayzi.Application.Buisness.Version.Queries.GetVersion;
using Pegov.Nasvayzi.Common;

namespace Pegov.Nasvayzi.Api.Controllers
{
    [Route("api/v{version:apiVersion}/home")]
    [ApiVersion(VersionController.Version1_0)]
    public class HomeController : BaseController
    {
        [HttpGet]
        public async Task<string> GetVersion(CancellationToken token)
            => await Mediator.Send(GetVersionQuery.Create(), token);
    }
}