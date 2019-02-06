using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Models;
using App.DomainServices.Identity;
using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Controllers
{
    [Authorize]
    public class ContactUsManagementController : Controller
    {
        private readonly ContactUsRepository _ContactUsRepository;
        public ContactUsManagementController(ContactUsRepository ContactUsRepository, BlogsRepository blogsRepository)
        {
            _ContactUsRepository = ContactUsRepository;
        }

        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public IActionResult Index()
        {
            var ContactUsList = _ContactUsRepository.GetAll();
            return View(ContactUsList);
        }
    }
}