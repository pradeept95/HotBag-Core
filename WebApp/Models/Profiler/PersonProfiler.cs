using AutoMapper;
using HotBag.AspNetCore.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Profiler
{
    public class PersonProfiler : HotBagProfilerBase
    {
        public PersonProfiler()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.DOB.Day))
                .ForMember(dest => dest.BirthMonth, opt => opt.MapFrom(src => src.DOB.Month))
                .ForMember(dest => dest.BirthYear, opt => opt.MapFrom(src => src.DOB.Year))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.MiddleName} {src.LastName}"));

            CreateMap<PersonDto, Person>()
               .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => new DateTime(src.BirthYear, src.BirthMonth, src.BirthDay)))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FullName.Split().FirstOrDefault()))
               .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.FullName.Split().Length == 3 ? src.FullName.Split()[1] : ""))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.FullName.Split().Length >= 2 ? src.FullName.Split().Last() : ""));
        }
    }
}
