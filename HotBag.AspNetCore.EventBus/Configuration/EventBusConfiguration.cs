using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotBag.AspNetCore.EventBus.Configuration
{
    /// <summary>
    /// EventBus configuration
    /// </summary>
    public static class EventBusConfiguration
    {
        /// <summary>
        /// It initialize all subscriber which of type ISubscriberBase from all assembly
        /// </summary>
        /// <returns></returns>

        public static async Task InitializeAllSubscriber()
        {
            var subscribers = new List<ISubscriberBase>();

            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);

            var assembly = runtimeAssemblyNames
               .Select(Assembly.Load)
               .SelectMany(a => a.ExportedTypes)
               .Where(t => TypeExtensions.GetInterfaces(t).Contains(typeof(ISubscriberBase)) && t.GetConstructor(Type.EmptyTypes) != null);
              
            var instances = assembly.Where(x => !x.IsAbstract).Select(y => (ISubscriberBase)Activator.CreateInstance(y));
            subscribers.AddRange(instances);

            foreach (var instance in subscribers)
            {
                instance.InitializeSubscription();
                await instance.InitializeSubscriptionAsync();
            }

        }
    }
}
