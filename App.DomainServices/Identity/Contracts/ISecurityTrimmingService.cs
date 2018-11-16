using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace App.DomainServices.Identity.Contracts
{
    public interface ISecurityTrimmingService
    {
        bool CanCurrentUserAccess(string area, string controller, string action);
        bool CanUserAccess(ClaimsPrincipal user, string area, string controller, string action);
    }
}