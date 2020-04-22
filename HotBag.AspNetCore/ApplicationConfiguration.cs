using HotBag.AspNetCore.CORS;
using HotBag.AspNetCore.Modules;
using HotBag.AspNetCore.ResultWrapper.Extensions;
using HotBag.AspNetCore.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HotBag.AspNetCore
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddHotBagCore(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            //services.AddSingleton(configuration); 

            services.AddHttpContextAccessor();

            //registering service for later use
            services.AddSingleton(services); 
             
            //register module,  register all dependencies
            new ModuleBootstrapper(services, serviceProvider);

            //register cors
            services.RegisterHotBagCORS(configuration, "Default");

            //register swagger
            //services.AddHotBagSwagger(
            //    new Swashbuckle.AspNetCore.Swagger.Info { 
            //        Title = "HB",
            //        Description = "Desc"
            //});
            return services;
        }


        public static IApplicationBuilder UseHotBagCore(this IApplicationBuilder app)
        {
            app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
            {
                appBuilder.UseHotBagResultWrapper();
            });

            //use hotbag swagger for swagger api documentation
            //app.UseHotBagSwagger();

            //use authentication
            app.UseAuthentication();

            app.UseCors("Default");

            return app;
        }

    }
}
