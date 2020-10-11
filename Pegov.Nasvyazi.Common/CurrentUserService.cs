using System;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Pegov.Nasvyazi.Common
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
        }

        public ICurrentUser CreateUserByToken(string jwt)
        {
            var jwtData = ReadJwtTokenExt(jwt);

            return CurrentUser.Create(jwtData.login, jwtData.firstName,
                jwtData.lastName, jwtData.middleName, jwtData.accountId,
                jwtData.organizationId, jwt, jwtData.roles);
        }

        public virtual ICurrentUser GetCurrentUser()
        {
            var jwt = GetJWTFromHttpContext();
            var jwtData = ReadJwtTokenExt(jwt);

            return CurrentUser.Create(jwtData.login, jwtData.firstName, 
                jwtData.lastName, jwtData.middleName, jwtData.accountId,
                jwtData.organizationId, jwt, jwtData.roles);
        }

        private string GetJWTFromHttpContext()
        {
            var jwt = (string)_contextAccessor.HttpContext?.Request?.Headers
                          ?.FirstOrDefault(x => x.Key == "Authorization").Value ?? string.Empty;

            if (string.IsNullOrEmpty(jwt.ToString()))
                jwt = _contextAccessor.HttpContext?.Request.Query["access_token"];

            if (jwt is null)
                jwt = null;
            else
                jwt = jwt
                    .Replace("Bearer ", string.Empty)
                    .Replace("bearer ", string.Empty);

            return jwt;
        }
       

        private (string firstName, string lastName, string middleName, long? organizationId, string[] roles) ReadJwtToken(string jwt)
        {
            if (string.IsNullOrEmpty(jwt))
                return (string.Empty, string.Empty, string.Empty, null, new string[] { });

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            var firstName = token.Claims.FirstOrDefault(x => x.Type.Equals("first_name"))?.Value;
            var lastName = token.Claims.FirstOrDefault(x => x.Type.Equals("last_name"))?.Value;
            var middleName = token.Claims.FirstOrDefault(x => x.Type.Equals("middle_name"))?.Value;

            long? organizationId = null;
            var organizationIdString = token.Claims.FirstOrDefault(x => x.Type.Equals("legal_id"))?.Value;
            if (!string.IsNullOrEmpty(organizationIdString))
                organizationId = long.Parse(organizationIdString);

            var roles = token.Claims.Where(x => x.Type.Equals("roles"));

            return (firstName, lastName, middleName, organizationId, roles?.Select(x => x.Value)?.ToArray());
        }

        private (string login, long accountId, string firstName, string lastName, string middleName, long? organizationId, string[] roles) ReadJwtTokenExt(string jwt)
        {
            if (string.IsNullOrEmpty(jwt))
                return (string.Empty, 0, string.Empty, string.Empty, string.Empty, null, new string[] { });

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            var firstName = token.Claims.FirstOrDefault(x => x.Type.Equals("first_name"))?.Value;
            var lastName = token.Claims.FirstOrDefault(x => x.Type.Equals("last_name"))?.Value;
            var middleName = token.Claims.FirstOrDefault(x => x.Type.Equals("middle_name"))?.Value;
            var login = token.Claims.FirstOrDefault(x => x.Type.Equals("login"))?.Value;
            var accountIdStr = token.Claims.FirstOrDefault(x => x.Type.Equals("user_id"))?.Value;

            long.TryParse(accountIdStr, out long accountId);

            long? organizationId = null;
            var organizationIdString = token.Claims.FirstOrDefault(x => x.Type.Equals("legal_id"))?.Value;
            if (!string.IsNullOrEmpty(organizationIdString))
                organizationId = long.Parse(organizationIdString);

            var roles = token.Claims.Where(x => x.Type.Equals("roles"));

            return (login, accountId, firstName, lastName, middleName, organizationId, roles?.Select(x => x.Value)?.ToArray());
        }
    }
}