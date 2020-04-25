using System;

namespace HotBag.AspNetCore.Automapper
{
    public sealed class NullObjectMapper// : IObjectMapper 
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static NullObjectMapper Instance { get; } = new NullObjectMapper();

        public TDestination Map<TDestination>(object source)
        {
            throw new NotImplementedException("HotBag.ObjectMapping.IObjectMapper should be implemented in order to map objects.");
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            throw new NotImplementedException("HotBag.ObjectMapping.IObjectMapper should be implemented in order to map objects.");

        }
    }
}
