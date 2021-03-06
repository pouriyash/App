﻿using System;
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
using Microsoft.AspNetCore.Hosting;
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
        private readonly IHostingEnvironment _environment;

        public ProductGalleryImageController(ProductGalleryImageRepository productGalleryImageRepository
            , IHostingEnvironment environment
            , FileConfig fileConfig)
        {
            _fileConfig = fileConfig;
            _environment = environment;
            _productGalleryImageRepository = productGalleryImageRepository;
        }

        public IActionResult Index(int ProductId)
        {
            ViewBag.ProductId = ProductId;
            var model = _productGalleryImageRepository.GetAll(ProductId);
            return View(model);
        }

        public IActionResult Create(int ProductId)
        {
            ViewBag.ProductId = ProductId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductGalleryImageDTO model, IFormFile Image)
        {
            var imageName = FileHelper.SaveFile(Image, _fileConfig, FileType.Image, _environment.WebRootPath);
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
                //FileHelper.DeleteFile(ImagePath, _fileConfig, FileType.Image, _environment.WebRootPath);

            TempData.AddResult(result);
            return RedirectToAction(nameof(Index), new { result.Data });
        }

    }
}