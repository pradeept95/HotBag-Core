﻿using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace HotBag.AspNetCore.Web
{
    public class GenericControllerRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            //if (controller.ControllerType.IsGenericType)
            //{
            //    var genericType = controller.ControllerType.GenericTypeArguments[0];
            //    var customNameAttribute = genericType.GetCustomAttribute<GeneratedControllerAttribute>();

            //    if (customNameAttribute?.Route != null)
            //    {
            //        controller.Selectors.Add(new SelectorModel
            //        {
            //            AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(customNameAttribute.Route)),        
            //        });
            //    }
            //    else
            //    {
            //        controller.ControllerName = genericType.Name;
            //    }
            //}
        }
    }
}
