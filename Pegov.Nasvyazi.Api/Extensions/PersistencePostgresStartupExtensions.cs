using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pegov.Nasvyazi.Application.Common.Interfaces;
using Pegov.Nasvyazi.Persistence.Postgres;

namespace Pegov.Nasvyazi.Api.Extensions
{
    public static class PersistencePostgresStartupExtensions
    {
        public static IServiceCollection AddPersistencePostgres(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetSection("ConnectionStrings:Database").Value,
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
            
            services.AddPersistencePostgres();
            
            return services;
        }
    }
}