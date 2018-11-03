using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace App.Common.Extentions.Identity
{
    public static class IdentityExtensions
    {

        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            return identity?.FindFirst(claimType)?.Value;
        }

        public static string GetUserClaimValue(this IIdentity identity, string claimType)
        {
            var identity1 = identity as ClaimsIdentity;
            return identity1?.FindFirstValue(claimType);
        }

        public static string GetUserId(this IIdentity identity)
        {
            return identity?.GetUserClaimValue(ClaimTypes.NameIdentifier);
        }
    }
}
