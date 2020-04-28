using HotBag.AspNetCore.AutoMapper;
using HotBag.AspNetCore.AutoMapper.Attributes;

namespace WebApp.Models.Profiler
{
    public class AddressProfiler : HotBagProfilerBase
    {
        public AddressProfiler()
        {

            CreateMap<AddressDto, Address>()
              .IgnoreAllNonExisting();
            
            //CreateMap<Address, AddressDto>()
            //  .IgnoreAllNonExisting();

            CreateMap<Address, AddressDto>()
                .ForMember(x => x.AddressLine3, opt => opt.Ignore());
        }
    }
}
