using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using App.Common.Extentions.Identity;
using App.Common.GuardToolkit;
using App.Common.Toolkit;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Identity;
using App.DomainModels.Entities.Models;
using App.DomainModels.ViewModels.Identity;
using App.DomainServices.Identity;
using App.DomainServices.Identity.Contracts;
using App.DomainServices.Repositories;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Controllers
{
    [Authorize(Roles = ConstantRoles.Admin)]
    public class DynamicRoleClaimsManagerController : Controller
    {
        private readonly IMvcActionsDiscoveryService _mvcActionsDiscoveryService;
        private readonly IApplicationRoleManager _roleManager;

        private const int DefaultPageSize = 10;

        public DynamicRoleClaimsManagerController
            (IMvcActionsDiscoveryService mvcActionsDiscoveryService, IApplicationRoleManager roleManager)

        {
            _mvcActionsDiscoveryService = mvcActionsDiscoveryService;
            _mvcActionsDiscoveryService.CheckArgumentIsNull(nameof(_mvcActionsDiscoveryService));

            _roleManager = roleManager;
            _roleManager.CheckArgumentIsNull(nameof(_roleManager));

        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var role = await _roleManager.FindRoleIncludeRoleClaimsAsync(id.Value);
            if (role == null)
            {
                return View("NotFound");
            }

            var securedControllerActions = _mvcActionsDiscoveryService.GetAllSecuredControllerActionsWithPolicy(ConstantPolicies.DynamicPermission);

            return View(model: new DynamicRoleClaimsManagerViewModel
            {
                SecuredControllerActions = securedControllerActions,
                RoleIncludeRoleClaims = role
            });
        }

        [AjaxOnly, HttpPost, ValidateAntiForgeryToken]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index(DynamicRoleClaimsManagerViewModel model)
        {
            var result = await _roleManager.AddOrUpdateRoleClaimsAsync(
                roleId: model.RoleId,
                roleClaimType: ConstantPolicies.DynamicPermissionClaimType,
                selectedRoleClaimValues: model.ActionIds);
            if (!result.Succeeded)
            {
                return BadRequest(error: result.DumpErrors(useHtmlNewLine: true));
            }
            return Json(new { success = true });
        }

    }
}