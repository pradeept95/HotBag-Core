using HotBag.AspNetCore.Reflection;
using HotBag.AspNetCore.SignalR.Attributes;
using HotBag.AspNetCore.SignalR.HubBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HotBag.AspNetCore.SignalR.Configuration
{
    public static class HotBagSignalRConfiguration
    {
        public static void RegisterAllHub(this HubRouteBuilder routes)
        { 
            var allAssembly = AssemblyHelper.Instance
                   .GetAllAssemblyInApplication();

            foreach (var assembly in allAssembly)
            {
                var candidates = assembly.GetExportedTypes().Where(x => x.GetCustomAttributes<UseHubRouteAttribute>().Any());

                foreach (var candidate in candidates)
                {
                    var route = candidate.GetCustomAttribute<UseHubRouteAttribute>();
                    if (route == null)
                    {
                        continue;
                    }

                    Type hubType = route.HubType; 
                    var method = routes.GetType().GetMethods().Single(
                                    m =>
                                        m.Name == "MapHub" &&
                                        m.GetGenericArguments().Length == 1 &&
                                        m.GetParameters().Length == 1 &&
                                        m.GetParameters()[0].ParameterType == typeof(PathString));

                    MethodInfo generic = method.MakeGenericMethod(hubType);

                    generic.Invoke(routes, new object[] { new PathString(route.RouteValue) });

                    //routes.MapHub<HotBagHubBase>(route.RouteValue);
                }
            }


        }
    }
}
