using System;

namespace HotBag.AspNetCore.Data.AppUser
{
    public class HotBagApplicationModulePermissionLevelDto
    {
        public long Id { get; set; }

        public long HotBagApplicationModuleId { get; set; }
        public ApplicationModulePermissionLevel PermissionLevel { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
