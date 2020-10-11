using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Pegov.Nasvyazi.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}