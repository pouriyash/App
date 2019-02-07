using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarMarWax.Models;
using App.DomainServices.Repositories;
using App.DomainModels.ViewModels.ContactUs;
using App.Common.Extentions;
using App.Common.Toolkit;
using Microsoft.AspNetCore.Authorization;
using App.DomainServices.Identity;

namespace MarMarWax.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ContactUsRepository _ContactUsRepository;
        public ContactUsController(ContactUsRepository ContactUsRepository)
        {
            _ContactUsRepository = ContactUsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactUsViewModel vm)
        {
            var result = _ContactUsRepository.Create(vm);
            TempData.AddResult(result);
            return View(nameof(Index));
        }

        //public IActionResult Edit(int Id)
        //{
        //    var entity = _ContactUsRepository.GetById(Id);
        //    return View(entity);
        //}

        //[HttpPost]
        //public IActionResult Edit(ContactUsViewModel vm,int Id)
        //{
        //    var result = _ContactUsRepository.Edit(vm,Id);
        //    TempData.AddResult(result);
        //    return Utility.CloseAndRefresh();
        //}
        

    }
}
