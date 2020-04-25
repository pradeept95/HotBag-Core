using HotBag.AspNetCore.AppSettings;
using HotBag.AspNetCore.AppSettings.Custom;
using HotBag.AspNetCore.Authorization;
using HotBag.AspNetCore.DI;
using HotBag.AspNetCore.EventBus.Configuration;
using HotBag.AspNetCore.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace HotBag.AspNetCore
{
    public class CoreModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "CoreModule"; } 
        }

        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {  
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var applicatonName = HotBagConfiguration.Configurations.ApplicationSettings.ApplicationName;

            //var nn = HotBagConfiguration.Configurations.ApplicationSettings.ApplicationName;

            //test of getting custom setting
             var customConfig = IocManager.Configurations.ServiceProvider.GetService<IDictionaryBasedConfig>();
             customConfig.Set("TestKey", "MyValue"); 
             var settingValue = customConfig.Get<string>("TestKey");
        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            Task.FromResult(EventBusConfiguration.InitializeAllSubscriber());
            AuthConfiguration.Configure(serviceCollection, configuration);

        }
    }
}
