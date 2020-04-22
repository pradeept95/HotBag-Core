using HotBag.AspNetCore.Data.EntityBase;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AspNetCore.Data.AppUser
{
    public class HotBagRole : EntityBase<long>
    {
        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; }
    }
}
