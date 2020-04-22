﻿using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace HotBag.AspNetCore.Authorization
{
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        readonly Claim _claim;
        readonly bool _requiredAllPermission = false;

        public ClaimRequirementFilter(Claim claim, bool requiredAllPermission)
        {
            _claim = claim;
            _requiredAllPermission = requiredAllPermission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Allow Anonymous skips all authorization
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                return;
            }

            var modulePermissions = _claim.Value.Split(',').Select(x => x.Trim()).ToList();
            var hasClaim = false;

            var assignedClaims = context.HttpContext.User.Claims.Where(c => c.Type == _claim.Type).Select(c => c.Value).FirstOrDefault()?.Split(',');

            if(assignedClaims == null)
            {
                assignedClaims = new string[0] { };
            } 

            if (_requiredAllPermission)
                hasClaim = modulePermissions.All(x => assignedClaims.Contains(x));
            else if (assignedClaims?.Length > 0)
                hasClaim = modulePermissions.Any(x => assignedClaims.Contains(x));
            else
                hasClaim = false;


            if (!hasClaim)
            {
                //get not assigned permission\  
                var unAssignedPermission = modulePermissions.FirstOrDefault(x => !assignedClaims.Contains(x));

                var arr = unAssignedPermission.Split('.').ToList();

                var msg = "";
                switch (arr.Count)
                {
                    case 1:
                        msg = arr.First();
                        break;
                    case 2:
                        msg = $"for {arr.First()} Module with {arr.Skip(1).First()} Policy";
                        break;
                    default:
                        break;
                }

                throw new System.UnauthorizedAccessException($"User does not have one of the required permission {msg}");
            }
        }
    }
}
