using HotBag.AspNetCore.Data.EntityBase;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBag.AspNetCore.Data.AppUser
{
    public class HotBagUserStatusLog : EntityBase<long>
    {
        [ForeignKey("HotBagUser")]
        public Guid UserId { get; set; }
        public virtual HotBagUser HotBagUser { get; set; }

        [Required]
        public UserStatus Status { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
