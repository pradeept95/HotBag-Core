namespace HotBag.AspNetCore.Data.AppUser
{
    public class HotBagRoleApplicationModuleDto
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long ApplicationModuleId { get; set; }
        public long? ApplicationModulePermissionLevelId { get; set; }
    }
}
