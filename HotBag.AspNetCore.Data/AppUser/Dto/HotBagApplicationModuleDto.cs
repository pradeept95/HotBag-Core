using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AspNetCore.Data.AppUser
{
    public class HotBagApplicationModuleDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Application Module Name is Required")]
        public string ModuleName { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
