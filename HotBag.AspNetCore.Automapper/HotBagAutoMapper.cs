﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotBag.AspNetCore.Data.Autofill;
using HotBag.AspNetCore.DI;
using System.Linq;

namespace HotBag.AspNetCore.AutoMapper.Attributes
{
    public class HotBagAutoMapper : IHotBagObjectMapper, ISingletonDependencies
    {
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configurationProvider;
        public HotBagAutoMapper(IMapper mapper, IConfigurationProvider configurationProvider)
        {
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }

        public TDestination Map<TDestination>(object source)
        {
            TDestination destinationObj = _mapper.Map<TDestination>(source);
            destinationObj.AutoFill();
            return destinationObj;
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            TDestination destinationObj = _mapper.Map(source, destination);
            destinationObj.AutoFill();
            return destinationObj;
        }

        public IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source)
        {
            return source.ProjectTo<TDestination>(_configurationProvider);
        }
    }
}
