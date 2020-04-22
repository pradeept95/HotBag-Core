using HotBag.AspNetCore.Data.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBag.AspNetCore.Data.AppUser
{
    public class HotBagApplicationModulePermissionLevel : EntityBase<long>
    {
        [ForeignKey("HotBagApplicationModule")]
        public long HotBagApplicationModuleId { get; set; }
        public virtual HotBagApplicationModule HotBagApplicationModule { get; set; }

        public ApplicationModulePermissionLevel PermissionLevel { get; set; }
    }
}
