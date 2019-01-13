using System;
using System.Collections.Generic;
using System.Linq;
using Alamut.Data.Structure;
using App.Admin.Helpers;
using App.Common.Extentions;
using App.DomainModels.Dto.Product;
using App.DomainModels.SSOT;
using App.DomainModels.ViewModels;
using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace App.Admin.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly ProductTypeRepository _productTypeRepository;
        private readonly FileConfig _fileConfig;

        public ProductsController
            (ProductRepository productRepository
            , FileConfig fileConfig
            , ProductTypeRepository productTypeRepository)

        {
            _productRepository = productRepository;
            _fileConfig = fileConfig;
            _productTypeRepository = productTypeRepository;
        }

        public IActionResult Index()
        {
            var model = _productRepository.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            var ProductTypes = _productTypeRepository.GetAll().Select(x => new { x.Id, Value = x.Title });

            ViewBag.ProductTypes = new SelectList(ProductTypes, "Id", "Value");

            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDTO model, IFormFile Image)
        {
            var imageName = FileHelper.SaveFile(Image, _fileConfig, FileType.Image);
            if (imageName != null)
                model.Image = imageName;
            var result = _productRepository.Create(model);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            var model = _productRepository.GetById(Id);
            if (model == null)
            {
                TempData.AddResult(ServiceResult.Error("نوعی یافت نشد!"));
                return View(nameof(Index));
            }
            var ProductTypes = _productTypeRepository.GetAll().Select(x => new { x.Id, Value = x.Title });

            ViewBag.ProductTypes = new SelectList(ProductTypes, "Id", "Value");

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model, int Id, IFormFile NewImage)
        {
            if (NewImage != null)
            {
                var imageName = FileHelper.SaveFile(NewImage, _fileConfig, FileType.Image);
                FileHelper.DeleteFile(model.Image, _fileConfig, FileType.Image);
                model.Image = imageName;
            }

            var result = _productRepository.Edit(model, Id);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Edit), new { Id });
        }


        public IActionResult Delete(int Id, string ImagePath)
        {
            var result = _productRepository.Delete(Id);
            if (result.Succeed)
                FileHelper.DeleteFile(ImagePath, _fileConfig, FileType.Image);

            TempData.AddResult(result);
            return RedirectToAction(nameof(Index));
        }
    }
}