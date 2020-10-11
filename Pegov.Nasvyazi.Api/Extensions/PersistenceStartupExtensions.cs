using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pegov.Nasvyazi.Application;
using Pegov.Nasvyazi.Persistence;

namespace Pegov.Nasvyazi.Api.Extensions
{
    public static class PersistenceStartupExtensions
    {
        public static IServiceCollection AddPersistenceRaven(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRavenStore>(x=> new RavenStore(new RavenOptions
            {
                ServerUrl = configuration.GetSection("RavenConnection:ServerUrl").Value,
                Database = configuration.GetSection("RavenConnection:Database").Value
            }));
            
            services.AddPersistence();
            
            return services;
        }
    }
}