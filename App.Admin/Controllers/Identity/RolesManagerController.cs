using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using App.Common.Extentions.Identity;
using App.Common.Toolkit;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Identity;
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
        private readonly IApplicationUserManager _userManager;

        private const int DefaultPageSize = 10;

        public RolesManagerController
            (PersonRepository personrepository, IApplicationRoleManager roleManager, IApplicationUserManager userManager)

        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        //[ActionContext]
        //public ActionContext ActionContext { get; set; }
        //public HttpContext HttpContext => ActionContext.HttpContext;
        public IActionResult Index()
        {
            var RoleList = _roleManager.GetAllCustomRolesAndUsersCountList();
            return View(RoleList);
        }

        #region ایجاد نقش جدید

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
                    return Utility.CloseAndRefresh();
                }
                ModelState.AddErrorsFromResult(result);
            }
            return View(vm);
        }

        #endregion

        #region ویرایش نقش

        public async Task<IActionResult> Edit(string RoleId)
        {
            var role =await _roleManager.FindByIdAsync(RoleId);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var role =await _roleManager.FindByIdAsync(vm.Id);
                if (role==null)
                {
                    //ارور
                    return View(nameof(Index));
                }
                else
                {
                    role.Name = vm.Name;
                    var result = await _roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return Json(new { success = true });
                    }
                    ModelState.AddErrorsFromResult(result);
                }
            }
            return View(nameof(Edit),new { RoleId=vm.Id.ToString()});

        }

        #endregion

        #region جذف نقش

        //[HttpPost]
        public async Task<IActionResult> Delete(int RoleId)
        {
            var role =await _roleManager.FindByIdAsync(RoleId.ToString());
            if (role==null)
            {
                //ارور نات فاند
                //ModelState.AddModelError("");
                return View("Index");
            }
            else
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }

                ModelState.AddErrorsFromResult(result);
                return View("Index");

            }

        }
        #endregion

        /// <summary>
        /// مدیریت کاربران و نقش هایشان
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="field"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<IActionResult> UsersInRole(int? id, int? page = 1, string field = "Id", SortOrder order = SortOrder.Ascending)
        {
            var model= await _roleManager.GetPagedApplicationUsersInRoleListAsync(
                roleId: id.Value,
                pageNumber: page.Value - 1,
                recordsPerPage: DefaultPageSize,
                sortByField: field,
                sortOrder: order,
                showAllUsers: true);

            model.Paging.CurrentPage = page.Value;
            model.Paging.ItemsPerPage = DefaultPageSize;
            model.Paging.ShowFirstLast = true;
            
            return View(model);
        }

        #region مدیریت نقش های کاربر

        public async Task<IActionResult> UserRolesManager(int userId)
        {
            var Roles = await _roleManager.GetAllCustomRolesAsync();
            var userwithRoles = _userManager.GetUserWithRolesByuserId(userId);
            return View(new Tuple<User, List<Role>>(userwithRoles, Roles));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserRoles(int userId, List<int> roleIds)
        {
            User thisUser = null;
            var result = await _userManager.AddOrUpdateUserRolesAsync(
                userId, roleIds, user => thisUser = user);
            if (!result.Succeeded)
            {
                return BadRequest(error: result.DumpErrors(useHtmlNewLine: true));
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}