using System.Linq;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Pegov.Nasvyazi.Api.Extensions;
using Pegov.Nasvyazi.Application;
using Pegov.Nasvyazi.Application.Infrastructure;
using Pegov.Nasvyazi.Common;

namespace pegov.Nasvyazi.Api
{
    public class Startup
    {
        private readonly Assembly _assemblyApplication = typeof(HandlerBase<,>).GetTypeInfo().Assembly;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IRavenStore>());

            services.AddOptions();

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"{nameof(Pegov.Nasvyazi.Api)}",
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.CustomSchemaIds(x => x.FullName);
                c.EnableAnnotations();
            });
            
            services
                .AddLogging(Configuration)         
                .AddPersistencePostgres(Configuration)
                .AddPersistenceRaven(Configuration)
                .AddAutoMapper(_assemblyApplication)
                .AddApplication();

            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddAutoMapper(_assemblyApplication);
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "Pegov.Nasvyazi.Api V1");
            });
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}