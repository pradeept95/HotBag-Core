using HotBag.AspNetCore.AutoMapper.Attributes;
using HotBag.AspNetCore.Data.EntityBase;
using System;

namespace WebApp.Models
{
    [AutoMapTo(typeof(Person))]
    public class PersonDto : EntityBaseDto<Guid>
    {
        public string FullName { get; set; }
        public string Address { get; set; }

        public int BirthDay { get; set; }
        public int BirthMonth { get; set; }
        public int BirthYear { get; set; }
    }
}
