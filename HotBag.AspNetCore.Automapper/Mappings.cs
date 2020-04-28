using AutoMapper;
using HotBag.AspNetCore.Reflection;
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
            var profiles = AssemblyHelper.Instance
                   .GetAllAssemblyInApplication()
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
