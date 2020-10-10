using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pegov.Nasvyazi.Persistence;

namespace Pegov.Nasvayzi.Api.Extensions
{
    public static class PersistenceStartupExtensions
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence();
            return services;
        }
    }
}