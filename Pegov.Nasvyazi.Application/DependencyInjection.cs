using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pegov.Nasvayzi.Application.Common.Behaviours;
using Prt.Graphit.Application.Common.Behaviours;

namespace Pegov.Nasvayzi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestRolesBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}