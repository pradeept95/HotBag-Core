using AutoMapper;
using HotBag.AspNetCore.Automapper.Extensions;
using HotBag.AspNetCore.Extensions;
using System;

namespace HotBag.AspNetCore.Automapper.Attributes
{
    public partial class AutoMapAttribute : AutoMapAttributeBase
    {
        public AutoMapAttribute(params Type[] targetTypes)
            : base(targetTypes)
        {

        }

        public override void CreateMap(IMapperConfigurationExpression configuration, Type type)
        {
            if (TargetTypes.IsNullOrEmpty())
            {
                return;
            }

            configuration.CreateAutoAttributeMaps(type, TargetTypes, MemberList.Source);

            foreach (var targetType in TargetTypes)
            {
                configuration.CreateAutoAttributeMaps(targetType, new[] { type }, MemberList.Destination);
            }
        }
    }
}
