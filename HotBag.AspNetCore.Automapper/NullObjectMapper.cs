using System;
using System.Linq;

namespace HotBag.AspNetCore.AutoMapper
{
    public sealed class NullObjectMapper : IHotBagObjectMapper
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static NullObjectMapper Instance { get; } = new NullObjectMapper();

        public TDestination Map<TDestination>(object source)
        {
            throw new NotImplementedException("HotBag.AspNetCore.Automapper.IObjectMapper should be implemented in order to map objects.");
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            throw new NotImplementedException("HotBag.AspNetCore.Automapper.IObjectMapper should be implemented in order to map objects.");

        }

        public IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source)
        {
            throw new NotImplementedException("HotBag.AspNetCore.Automapper.IObjectMapper should be implemented in order to map objects.");
        }
    }
}
