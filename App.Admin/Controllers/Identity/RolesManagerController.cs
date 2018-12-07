using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Common.Extentions.Identity;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Models;
using App.DomainModels.ViewModels.Identity;
using App.DomainServices.Identity.Contracts;
using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Controllers
{
    [Authorize]
    public class RolesManagerController : Controller
    {
        private readonly IApplicationRoleManager _roleManager;
        public RolesManagerController
            (PersonRepository personrepository, IApplicationRoleManager roleManager)

        {
            _roleManager = roleManager;
        }
        //[ActionContext]
        //public ActionContext ActionContext { get; set; }
        //public HttpContext HttpContext => ActionContext.HttpContext;
        public IActionResult Index()
        {
            var RoleList = _roleManager.GetAllCustomRolesAndUsersCountList();
            return View(RoleList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new DomainModels.Entities.Identity.Role { Name = vm.Name });
                if (result.Succeeded)
                {
                    return View(nameof(Index));
                }
                ModelState.AddErrorsFromResult(result);
            }
            return View(vm);
        }
    }
}