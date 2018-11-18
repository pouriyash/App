using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Models;
using App.DomainModels.ViewModels.Identity;
using App.DomainServices.Identity;
using App.DomainServices.Repositories;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Controllers
{
    /// <summary>
    /// More info: http://www.dotnettips.info/post/2581
    /// </summary>
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [BreadCrumb(UseDefaultRouteUrl = true, Order = 0)]
    [DisplayName("کنترلر نمونه با سطح دسترسی پویا")]
    public class DynamicPermissionsSampleController : Controller
    {
        [DisplayName("ایندکس")]
        [BreadCrumb(Order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(RoleViewModel model)
        {
            return View(model);
        }

        [DisplayName("گزارش از لیست کتاب‌ها")]
        [BreadCrumb(Order = 1)]
        public IActionResult Books()
        {
            return View(viewName: "Index");
        }

        [DisplayName("گزارش از لیست مراجعان")]
        [BreadCrumb(Order = 1)]
        public IActionResult Users()
        {
            return View(viewName: "Index");
        }

        [DisplayName("گزارش از لیست امانات")]
        [BreadCrumb(Order = 1)]
        public IActionResult BooksGiven()
        {
            return View(viewName: "Index");
        }

        [DisplayName("گزارش از لیست مفقودی‌ها")]
        [BreadCrumb(Order = 1)]
        public IActionResult BooksMissings()
        {
            return View(viewName: "Index");
        }
    }
}