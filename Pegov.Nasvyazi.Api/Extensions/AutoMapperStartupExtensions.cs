using System;
using System.Diagnostics;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Pegov.Nasvyazi.Api.Extensions
{
    public static class AutoMapperStartupExtensions
    {
        public static void AutoMapperConfigure(this IWebHostEnvironment env, 
            Assembly assembly, IApplicationBuilder app)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(assembly);
            });

            if (env != null && env.IsDevelopment())
            {
                //var opt = app.ApplicationServices
                //.GetRequiredService<Microsoft.Extensions.Options.IOptions<Common.Settings.Models.Host>>();

                try
                {
                    
                    config.AssertConfigurationIsValid();
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                    Debugger.Break();
                    throw;
                }
            }
        }
    }
}