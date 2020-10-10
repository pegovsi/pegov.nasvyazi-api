using Microsoft.AspNetCore.Mvc;

namespace pegov.nasvayzi.Api.Filters
{
    [Microsoft.AspNetCore.Mvc.Infrastructure.DefaultStatusCode(500)]
    public class InternalServerErrorObjectResult : ObjectResult
    {
        private const int DefaultStatusCode = 500;

        public InternalServerErrorObjectResult(object value)
            : base(value)
        {
            this.StatusCode = new int?(DefaultStatusCode);
        }
    }
}