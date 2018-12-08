using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using App.Common.Extentions.Identity;
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
    public class UsersManagerController : Controller
    {
        private readonly IApplicationUserManager _userManager;

        private const int DefaultPageSize = 10;

        public UsersManagerController
            (PersonRepository personrepository, IApplicationUserManager userManager)

        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
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

            return View(ReturnUrl);
        }

        #endregion

    }
}