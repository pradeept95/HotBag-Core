using AutoMapper;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace HotBag.AspNetCore.AutoMapper
{
    public static class Mappings
    {
        public static IMapperConfigurationExpression RegisterHotBagProfiler(this IMapperConfigurationExpression cfg)
        {  

            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);
            var profiles = runtimeAssemblyNames
               .Select(Assembly.Load)
               .SelectMany(a => a.ExportedTypes)
               .Where(t => TypeExtensions.GetInterfaces(t).Contains(typeof(IHotBagProfile)) && t.GetConstructor(Type.EmptyTypes) != null)
               .Select(y => (Profile)Activator.CreateInstance(y));

            foreach (var profile in profiles)
            {
                cfg.AddProfile(profile);
            }

         
            return cfg;
        }

    }
}
