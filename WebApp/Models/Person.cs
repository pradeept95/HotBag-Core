using AutoMapper;
using HotBag.AspNetCore.AutoMapper.Attributes;
using HotBag.AspNetCore.Data.Autofill;
using HotBag.AspNetCore.Data.EntityBase;
using System;

namespace WebApp.Models
{
    [AutoMap(typeof(PersonDto))]
    public class Person : EntityBase<Guid>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
         
        public DateTime DOB { get; set; }
    }

    [AutoMap(typeof(AddressDto))]
    public class Address : EntityBase<Guid>
    {

        public string AddressLine1 { get; set; }

        [IgnoreMap]
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

    }
}
