using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarWax.Components
{
    public class MenuComponents: ViewComponent
    {
        private readonly ProductTypeRepository _productTypeRepository;
        public MenuComponents(ProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.productTypes = _productTypeRepository.GetAll();
            return View(viewName: "Menu");
        }

    }
}
