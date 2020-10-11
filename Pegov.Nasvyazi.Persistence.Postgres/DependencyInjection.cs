using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Pegov.Nasvyazi.Persistence.Postgres
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistencePostgres(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
