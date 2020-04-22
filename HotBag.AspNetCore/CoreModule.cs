using HotBag.AspNetCore.Authorization;
using HotBag.AspNetCore.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            //Auto Mapper Configurations
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.ValidateInlineMaps = false;
            //    mc.AddProfile(new MappingProfile());
            //});

            //IMapper mapper = mappingConfig.CreateMapper();
            //serviceCollection.AddSingleton(mapper);

            //Mappings.RegisterMappings();
            //serviceCollection.AddSingleton(typeof(HotBag.AutoMaper.IObjectMapper), typeof(HotBagAutoMapper));
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //var applicatonName = HotBagConfiguration.Configurations.ApplicationSettings.ApplicationName;

            //var nn = HotBagConfiguration.Configurations.ApplicationSettings.ApplicationName;

            //test of getting custom setting
            // var customConfig = IocManager.Configurations.Manager.GetService<IDictionaryBasedConfig>();
            //var settingValue = customConfig.Get<string>("myCustomSetting");
        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //serviceCollection.AddScoped<HotBagDbContext>();

            //var all =
            //   Assembly
            //      .GetEntryAssembly()
            //      .GetReferencedAssemblies()
            //      .Select(Assembly.Load);

            //serviceCollection.AddAutoMapper(all);
             
            AuthConfiguration.Configure(serviceCollection, configuration);

            //var customConfig = IocManager.Configurations.Manager.GetService<IDictionaryBasedConfig>();

            //customConfig.Set<string>("myCustomSetting", "my custom setting value");
        }
    }
}
