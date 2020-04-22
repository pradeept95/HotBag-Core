using HotBag.AspNetCore.DI.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HotBag.AspNetCore.Bootstraper
{
    public class Bootstrapper : IBootstrapper
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IConfiguration _configuration;
        public Bootstrapper(IServiceCollection serviceCollection, IServiceProvider serviceProvider)
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
            var serviceInstances = new List<IServiceRegistrar>();
             

            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);

            var instances = runtimeAssemblyNames
                .Select(Assembly.Load)
                .SelectMany(a => a.ExportedTypes)
                .Where(t => TypeExtensions.GetInterfaces(t).Contains(typeof(IServiceRegistrar)) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(y => (IServiceRegistrar)Activator.CreateInstance(y));
            serviceInstances.AddRange(instances);

            foreach (var instance in serviceInstances)
            {   //TODO::check module is installed or not
                instance.Register(_serviceCollection, _configuration);
            }
            //var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            //    .Where(a => a.GetTypes().Contains(typeof(ApiController)))
            //    .ToArray();
            //// Register your Web API controllers.

            //Builder.RegisterApiControllers(assemblies);
            // AutofacPlugin.Register(Builder);
            // Container = (Container)Builder.Build();

            //TODO build
            //_serviceCollection.BuildServiceProvider();

            foreach (var instance in serviceInstances)
            {
                instance.Update(_serviceCollection);
            }

            // DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
            // GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);

        }

    }
}
