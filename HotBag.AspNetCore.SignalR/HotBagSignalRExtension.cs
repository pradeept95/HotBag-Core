using HotBag.AspNetCore.SignalR.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.AspNetCore.SignalR
{
    public static class HotBagSignalRExtension
    {
        public static IApplicationBuilder UseHotBagSignalR(this IApplicationBuilder app)
        {

            app.UseSignalR(routes =>
            {
                routes.RegisterAllHub();
            });
            return app;
        }

        public static IServiceCollection AddHotBagSignalR(this IServiceCollection service)
        {
            service.AddSignalR();
            return service;
        }
    }
}
