using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AspNetCore.Data.AppUser
{
    public class HotBagUserStatusLogDto
    {
        public long Id { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public UserStatus Status { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
