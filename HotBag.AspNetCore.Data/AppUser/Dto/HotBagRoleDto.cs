using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AspNetCore.Data.AppUser
{
    public class HotBagRoleDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
