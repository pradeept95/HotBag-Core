using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.AspNetCore.SignalR.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class UseHubRouteAttribute : Attribute
    {
        public string RouteValue;
        public Type HubType;

        public UseHubRouteAttribute(string routeValue, Type typeOfThis)
        {
            this.RouteValue = routeValue;
            this.HubType = typeOfThis;
        }
    }
}
