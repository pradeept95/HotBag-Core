using HotBag.AspNetCore.AppSettings;
using HotBag.AspNetCore.AutoMapper.Configuration;
using HotBag.AspNetCore.CORS;
using HotBag.AspNetCore.EventBus.Configuration;
using HotBag.AspNetCore.Modules;
using HotBag.AspNetCore.ResultWrapper.Extensions;
using HotBag.AspNetCore.Swagger;
using HotBag.AspNetCore.Web.BaseRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

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

            //enable automapper
            if (HotBagConfiguration.Configurations.ApplicationSettings.Features.IsEnableAutoMapper)
                services.AddHotBagAutoMapper();

            //register cors
            if (HotBagConfiguration.Configurations.ApplicationSettings.Features.IsEnableCORS)
                services.RegisterHotBagCORS(configuration, "Default");

            //register swagger
            if (HotBagConfiguration.Configurations.ApplicationSettings.Features.IsEnableSwaggerApiDoc) 
                services.AddHotBagSwagger(
                   new Microsoft.OpenApi.Models.OpenApiInfo
                   {
                       Title = "HotBag Enterprise Application",
                       Description = ""
                   }); 

            if (HotBagConfiguration.Configurations.ApplicationSettings.Features.IsEnableEventBus)
                Task.FromResult(EventBusConfiguration.InitializeAllSubscriber());


            //services.AddScoped(typeof(BaseRepository<,>), typeof(IBaseRepository<,>));


            return services;
        }


        public static IApplicationBuilder UseHotBagCore(this IApplicationBuilder app)
        {
            if (HotBagConfiguration.Configurations.ApplicationSettings.Features.IsEnableResultWrapper)
                app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
                {
                    appBuilder.UseHotBagResultWrapper();
                }); 

            //use hotbag swagger for swagger api documentation
            if (HotBagConfiguration.Configurations.ApplicationSettings.Features.IsEnableSwaggerApiDoc)
                 app.UseHotBagSwagger();


            //use authentication
            app.UseAuthentication();

            app.UseCors("Default");

            return app;
        }

    }
}
