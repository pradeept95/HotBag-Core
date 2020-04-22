﻿using HotBag.AspNetCore.Data.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBag.AspNetCore.Data.AppUser
{
    public class HotBagRoleApplicationModule : EntityBase<long>
    {
        [ForeignKey("HotBagRole")]
        public long RoleId { get; set; }
        public virtual HotBagRole HotBagRole { get; set; }

        [ForeignKey("HotBagApplicationModule")]
        public long ApplicationModuleId { get; set; }
        public virtual HotBagApplicationModule HotBagApplicationModule { get; set; }

        [ForeignKey("HotBagApplicationModulePermissionLevel")]
        public long? ApplicationModulePermissionLevelId { get; set; }
        public virtual HotBagApplicationModulePermissionLevel HotBagApplicationModulePermissionLevel { get; set; }
    }
}
