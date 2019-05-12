using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alamut.Data.Structure;
using App.Admin.Helpers;
using App.Common.Extentions;
using App.Data.Sql.Context;
using App.DomainModels.Dto;
using App.DomainModels.Entities.Models;
using App.DomainModels.SSOT;
using App.DomainModels.ViewModels;
using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Controllers
{
    [Authorize]
    public class SliderController : Controller
    {
        private readonly sliderRepository _sliderRepository;
        private readonly FileConfig _fileConfig;
        private readonly IHostingEnvironment _environment;

        public SliderController(sliderRepository sliderRepository
            , IHostingEnvironment environment
            , FileConfig fileConfig)
        {
            _fileConfig = fileConfig;
            _sliderRepository = sliderRepository;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var model = _sliderRepository.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(sliderDTO model, IFormFile Image)
        {
            var imageName = FileHelper.SaveFile(Image, _fileConfig, FileType.Image, _environment.WebRootPath);
            if (imageName != null)
                model.Image = imageName;
            var result = _sliderRepository.Create(model);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            var model = _sliderRepository.GetById(Id);
            if (model == null)
            {
                TempData.AddResult(ServiceResult.Error("مقاله ای یافت نشد!"));
                return View(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(sliderViewModel model, int Id, IFormFile NewImage)
        {

            if (NewImage != null)
            {
                var imageName = FileHelper.SaveFile(NewImage, _fileConfig, FileType.Image, _environment.WebRootPath);
                //FileHelper.DeleteFile(model.Image, _fileConfig, FileType.Image, _environment.WebRootPath);
                model.Image = imageName;
            }

            var result = _sliderRepository.Edit(model, Id);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id, string ImagePath)
        {
            var result = _sliderRepository.Delete(Id);
            if (result.Succeed)
                //FileHelper.DeleteFile(ImagePath, _fileConfig, FileType.Image, _environment.WebRootPath);

            TempData.AddResult(result);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult View(int Id)
        {
            var result = _sliderRepository.Delete(Id);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Index));
        }

    }
}