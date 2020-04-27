using HotBag.AspNetCore.AppSettings;
using HotBag.AspNetCore.DI;
using HotBag.AspNetCore.EventBus;
using HotBag.AspNetCore.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Web.Host.Subscriber;

namespace Web.Host
{
    public class WebHostModule : ApplicationModule
    {
        public override string ModuleName => "WebHostModule";

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        { 
            //SentDetailExceptionMessage to false to prevent send back with stacktrace
            HotBagConfiguration.Configurations.ApplicationSettings.SentDetailExceptionMessage = false;
            HotBagConfiguration.Configurations.ApplicationSettings.Features.IsEnableSwaggerApiDoc = true;
            HotBagConfiguration.Configurations.ApplicationSettings.Features.IsEnableResultWrapper = true;
        }
    }

}
