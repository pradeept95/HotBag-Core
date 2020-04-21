using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotBag.AspNetCore.Authorization
{
    public class HotBagAuthorizeAttribute : TypeFilterAttribute
    {
        public HotBagAuthorizeAttribute(string claimType, string claimValue, bool RequiredAllPermission = false) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] {
                new Claim(claimType, claimValue),
                RequiredAllPermission
            };
        }
    }
}
