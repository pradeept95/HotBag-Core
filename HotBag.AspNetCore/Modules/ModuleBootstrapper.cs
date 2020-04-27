using HotBag.AspNetCore.AppSettings;
using HotBag.AspNetCore.AutoMapper.Configuration;
using HotBag.AspNetCore.DI;
using HotBag.AspNetCore.Installer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HotBag.AspNetCore.Modules
{
    internal class ModuleBootstrapper : IModuleBootstrapper
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IConfiguration _configuration;
        public ModuleBootstrapper(IServiceCollection serviceCollection, IServiceProvider serviceProvider)
        {
            _serviceCollection = serviceCollection;
            _configuration = serviceProvider.GetService<IConfiguration>();
            Init();
        }

        public void Init()
        {
            Build();
        }

        public bool Build()
        {
            FindThenBuild();
            return true;
        }

        private void FindThenBuild()
        {
            var moduleInstances = new List<IApplicationModule>();

            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);
              
            //register all dependency having singleton, scoped and transit
            RegisterDependency.RegisterAll(_serviceCollection);

            //register application settings
            // 1 : add services to container
            // 2 : initialize all settings
            _serviceCollection.RegisterApplicationSettings();
            HotBagConfiguration.Configurations.Initialize(_serviceCollection);

            IocManager.Configurations.Initialize(_serviceCollection, _configuration); // allow applicaton usases the state through out  the applicaton
            

            var instances = runtimeAssemblyNames
                .Select(Assembly.Load)
                .SelectMany(a => a.ExportedTypes)
                .Where(t => TypeExtensions.GetInterfaces(t).Contains(typeof(IApplicationModule)) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(y => (IApplicationModule)Activator.CreateInstance(y));
            moduleInstances.AddRange(instances);

            DefaultInstaller.RegisterAllModule(moduleInstances);
            DefaultInstaller.InstallDefaultModule();
            DefaultInstaller.InstallApplicationORMModule();
            DefaultInstaller.InstallApplicationModule();

            foreach (var instance in moduleInstances)
            {   //TODO::check module is installed or not 
                if (HotBagConfiguration.Configurations.ModuleSetting.IsModuleInstalled(instance.ModuleName))
                    instance.PreInitialize(_serviceCollection, _configuration);
            }

            foreach (var instance in moduleInstances)
            {
                if (HotBagConfiguration.Configurations.ModuleSetting.IsModuleInstalled(instance.ModuleName))
                    instance.Initialize(_serviceCollection, _configuration);
            }

            foreach (var instance in moduleInstances)
            {
                if (HotBagConfiguration.Configurations.ModuleSetting.IsModuleInstalled(instance.ModuleName))
                    instance.PostInitialize(_serviceCollection, _configuration);
            }
        }

    }
}
