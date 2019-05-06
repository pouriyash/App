using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alamut.Data.Structure;
using App.Common.Extentions;
using App.Common.Toolkit;
using App.Data.Sql.Context;
using App.DomainModels.Dto.Product;
using App.DomainModels.Entities.Models;
using App.DomainModels.ViewModels;
using App.DomainModels.ViewModels.Product;
using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    [Authorize]
    public class ProductColorController : Controller
    {
        private readonly ProductColorRepository _productColorRepository;
        public ProductColorController
            (ProductColorRepository productColorRepository)

        {
            _productColorRepository = productColorRepository;
        }

        public IActionResult Index(int ProductId)
        {
            ViewBag.productId = ProductId;
           var model= _productColorRepository.GetAll(ProductId);
            return View(model);
        }
         

        [HttpPost]
        public IActionResult Create(ProductColorSummaryDTO model)
        {
            var result = _productColorRepository.Create(model);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Index),new { ProductId=model.ProductId });
        }

        public IActionResult Edit(int Id)
        {
            var model = _productColorRepository.GetById(Id);
            if (model==null)
            {
                TempData.AddResult(ServiceResult.Error("نوعی یافت نشد!"));
                return View(nameof(Index), new { ProductId = model.ProductId });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductColorEditViewModel model,int Id)
        {
            var result = _productColorRepository.Edit(model,Id);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Edit),new { Id });
        }

   
        public IActionResult Delete(int Id)
        {
            var result = _productColorRepository.Delete(Id);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Index), new { ProductId = result.Data });
        }
    }
}