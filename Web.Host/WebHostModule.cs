using HotBag.AspNetCore.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Host.Subscriber;

namespace Web.Host
{
    public class WebHostModule : ApplicationModule
    {
        public override string ModuleName => "WebHostModule";

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var subscriber = new SubscriberEvent();
            subscriber.InitializeSubscription(); 
        }
    }

}
