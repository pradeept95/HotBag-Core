using System;

namespace HotBag.AspNetCore.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GeneratedControllerAttribute : Attribute
    {
        public Type EntityDtoType;
        public Type PrimaryKeyType;
        public GeneratedControllerAttribute(Type typeOfEntityDto, Type typeOfPrimaryKey)
        {
            EntityDtoType = typeOfEntityDto;
            PrimaryKeyType = typeOfPrimaryKey;
        }
    }
}
