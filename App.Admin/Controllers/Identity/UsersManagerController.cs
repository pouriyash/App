using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using App.Common.Extentions;
using App.Common.Extentions.Identity;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Identity;
using App.DomainModels.Entities.Models;
using App.DomainModels.ViewModels.Identity;
using App.DomainServices.Identity.Contracts;
using App.DomainServices.Repositories;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Controllers
{
    [Authorize]
    public class UsersManagerController : Controller
    {
        private readonly IApplicationUserManager _userManager;

        private const int DefaultPageSize = 10;

        public UsersManagerController
            (PersonRepository personrepository, IApplicationUserManager userManager)

        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int? page=1,string field="Id",SortOrder order=SortOrder.Ascending)
        {
            var model =await _userManager.GetPagedUsersListAsync(
                pageNumber: page.Value - 1,
                recordsPerPage: DefaultPageSize,
                sortByField: field,
                sortOrder: order,
                showAllUsers: true);

            model.Paging.CurrentPage = page.Value;
            model.Paging.ItemsPerPage = DefaultPageSize;
            model.Paging.ShowFirstLast = true;

            //نمیدونم چیه؟؟؟
            if (HttpContext.Request.IsAjaxRequest())
            {
                return PartialView("_UsersList", model);
            }

            return View(model);
        }

        #region وضعیت ها

        public async Task<IActionResult> ChangeUserActive(int userId,bool activate,string ReturnUrl)
        {
            User thisUser = null;
            var result = await _userManager.UpdateUserAndSecurityStampAsync(
                userId, user =>
                {
                    user.IsActive = activate;
                    thisUser = user;
                });
            if (!result.Succeeded)
            {
                return BadRequest(error: result.DumpErrors(useHtmlNewLine: true));
            }
            TempData.AddResult(new Alamut.Data.Structure.ServiceResult { Message="عملیات با موفقیت انجام شد!",Succeed=true,StatusCode=200});
            return View(ReturnUrl);
        }

        #endregion

    }
}