using System;

namespace HotBag.AspNetCore.Data.AppUser
{
    public class HotBagUserRolesDto
    {
        public long Id { get; set; }

        public Guid UserId { get; set; }
        public long RoleIdId { get; set; }
    }
}
