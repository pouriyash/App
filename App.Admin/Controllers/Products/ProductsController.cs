using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alamut.Data.Structure;
using App.Common.Extentions;
using App.Data.Sql.Context;
using App.DomainModels.Dto.Product;
using App.DomainModels.Entities.Models;
using App.DomainModels.ViewModels;
using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;
        public ProductsController
            (ProductRepository productRepository)

        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var model = _productRepository.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDTO model)
        {
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
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model, int Id)
        {
            var result = _productRepository.Edit(model, Id);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Edit), new { Id });
        }


        public IActionResult Delete(int Id)
        {
            var result = _productRepository.Delete(Id);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Index));
        }
    }
}