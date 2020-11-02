using System.Security.Claims;
using Pegov.Nasvyazi.Application.Services.Identity;

namespace Pegov.Nasvyazi.Application.Common.Interfaces
{
    public interface IJwtManager
    {
        SessionUser GenerationToken(ClaimsIdentity claim, ApplicationUser account);
    }
}