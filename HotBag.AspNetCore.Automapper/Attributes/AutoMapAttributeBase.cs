using AutoMapper;
using System;

namespace HotBag.AspNetCore.Automapper.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class AutoMapAttributeBase : Attribute
    {
        public Type[] TargetTypes { get; private set; }

        protected AutoMapAttributeBase(params Type[] targetTypes)
        {
            TargetTypes = targetTypes;
        }

        public abstract void CreateMap(IMapperConfigurationExpression configuration, Type type);
    }
}
