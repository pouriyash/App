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
using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Controllers
{
    [Authorize]
    public class ProductTypesController : Controller
    {
        private readonly ProductTypeRepository _productTypeRepository;
        public ProductTypesController
            (ProductTypeRepository productTypeRepository)

        {
            _productTypeRepository = productTypeRepository;
        }

        public IActionResult Index()
        {
            _productTypeRepository.GetAll();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductTypeDTO model)
        {
            var result = _productTypeRepository.Create(model);
            TempData.AddResult(result);
            return Utility.CloseAndRefresh();
        }

        public IActionResult Edit(int Id)
        {
            var model = _productTypeRepository.GEtById(Id);
            if (model==null)
            {
                TempData.AddResult(ServiceResult.Error("نوعی یافت نشد!"));
                return View(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductTypeEditViewModel model,int Id)
        {
            var result = _productTypeRepository.Edit(model,Id);
            TempData.AddResult(result);
            return Utility.CloseAndRefresh();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var result = _productTypeRepository.Delete( Id);
            TempData.AddResult(result);
            return Utility.CloseAndRefresh();
        }
    }
}