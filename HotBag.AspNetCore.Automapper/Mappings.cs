using AutoMapper;
using System.Linq;
using System.Reflection;

namespace HotBag.AspNetCore.Automapper
{
    public class Mappings
    {
        public static void RegisterMappings()
        {
            var all =
            Assembly
               .GetEntryAssembly()
               .GetReferencedAssemblies()
               .Select(Assembly.Load)
               .SelectMany(x => x.DefinedTypes)
               .Where(type => typeof(IHotBagProfile).GetTypeInfo().IsAssignableFrom(type.AsType()));

            foreach (var ti in all.Where(ti => ti.AsType().Equals(typeof(IHotBagProfile))))
            {
                
                    //Mapper.Initialize(cfg =>
                    //{
                    //    cfg.AddProfiles(t); // Initialise each Profile classe
                    //});

                    var config = new MapperConfiguration(cfg => {
                        cfg.AddProfile(ti.AsType());
                    });

                    var mapper = config.CreateMapper(); 
            }
        }

    }
}
