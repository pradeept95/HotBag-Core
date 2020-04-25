using AutoMapper;
using HotBag.AspNetCore.AutoMapper.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HotBag.AspNetCore.AutoMapper.Configuration
{
    public static class HotBagAutomapperConfiguration
    {
        public static IServiceCollection AddHotBagAutoMapper(this IServiceCollection service)
        {
            var all =
             Assembly
                .GetEntryAssembly()
                .GetReferencedAssemblies()
                .Select(Assembly.Load);

            service.AddAutoMapper(all);


            //Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                  mc.RegisterHotBagProfiler();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            service.AddSingleton(mapper);

            //Mappings.RegisterMappings();
            service.AddSingleton(typeof(IHotBagObjectMapper), typeof(HotBagAutoMapper));

            return service;
        }
    }
}
