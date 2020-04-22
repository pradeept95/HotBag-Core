using HotBag.AspNetCore.Data.EntityBase;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBag.AspNetCore.Data.AppUser
{
    public class HotBagUserRoles : EntityBase<long>
    {
        [ForeignKey("HotBagUser")]
        public Guid UserId { get; set; }
        public virtual HotBagUser HotBagUser { get; set; }

        [ForeignKey("HotBagRole")]
        public long RoleIdId { get; set; }
        public virtual HotBagRole HotBagRole { get; set; }
    }
}
