using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Pegov.Nasvyazi.Application.Services.Identity
{
    public class AuthorizationOptions
    {
        public const string ISSUER = "Pegov.NaSvyazi.IdentityServer.V1"; // издатель токена
        public const string AUDIENCE = "https://super.messenger.2020.io/"; // потребитель токена
        public const string KEY = "NaSvyazi!_999@Pegov.NaSvyazi.KEY2020";   // ключ для шифрации
        public const int LIFETIME = 1140; // время жизни токена =  1140 минут

        public static SymmetricSecurityKey Create(string secret)
            => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
    }
}