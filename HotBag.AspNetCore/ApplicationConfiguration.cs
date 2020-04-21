using HotBag.AspNetCore.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HotBag.AspNetCore
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection RegisterHotBagCore(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            //services.AddSingleton(configuration); 

            services.AddHttpContextAccessor();

            //registering service for later use
            services.AddSingleton(services); 
             
            //register module,  register all dependencies
            new ModuleBootstrapper(services, serviceProvider);
            return services;
        }
    }
}
