using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alamut.Data.Structure;
using App.Admin.Helpers;
using App.Common.Extentions;
using App.Data.Sql.Context;
using App.DomainModels.Dto.Product;
using App.DomainModels.Entities.Models;
using App.DomainModels.SSOT;
using App.DomainModels.ViewModels.Product;
using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Controllers
{
    [Authorize]
    public class ProductGalleryImageController : Controller
    {
        private readonly ProductGalleryImageRepository _productGalleryImageRepository;
        private readonly FileConfig _fileConfig;

        public ProductGalleryImageController(ProductGalleryImageRepository productGalleryImageRepository
            , FileConfig fileConfig)
        {
            _fileConfig = fileConfig;
            _productGalleryImageRepository = productGalleryImageRepository;
        }

        public IActionResult Index(int productId)
        {
            var model = _productGalleryImageRepository.GetAll(productId);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductGalleryImageDTO model, IFormFile Image)
        {
            var imageName = FileHelper.SaveFile(Image, _fileConfig, FileType.Image);
            if (imageName != null)
                model.Image = imageName;
            var result = _productGalleryImageRepository.Create(model);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Index), new { model.ProductId });
        }
         
        public IActionResult Delete(int Id, string ImagePath)
        {
            var result = _productGalleryImageRepository.Delete(Id);
            if (result.Succeed)
                FileHelper.DeleteFile(ImagePath, _fileConfig, FileType.Image);

            TempData.AddResult(result);
            return RedirectToAction(nameof(Index), new { result.Data });
        }

    }
}