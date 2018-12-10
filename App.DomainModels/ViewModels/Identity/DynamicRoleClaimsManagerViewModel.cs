﻿using App.DomainModels.Entities.Identity;
using DNTCommon.Web.Core;
using System;
using System.Collections.Generic;
 
namespace App.DomainModels.ViewModels.Identity
{
    public class DynamicRoleClaimsManagerViewModel
    {
        public string[] ActionIds { set; get; }

        public int RoleId { set; get; }

        public Role RoleIncludeRoleClaims { set; get; }

        public ICollection<MvcControllerViewModel> SecuredControllerActions { set; get; }

    }
}
