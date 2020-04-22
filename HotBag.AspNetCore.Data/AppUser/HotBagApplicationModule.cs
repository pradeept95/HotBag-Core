using HotBag.AspNetCore.Data.EntityBase;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AspNetCore.Data.AppUser
{
    public class HotBagApplicationModule : EntityBase<long>
    {
        [Required(ErrorMessage = "Application Module Name is Required")]
        public string ModuleName { get; set; }
    }
}
