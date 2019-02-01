using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarMarWax.Models;
using App.DomainServices.Repositories;

namespace MarMarWax.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly ProductTypeRepository _productTypeRepository;
        public ProductController(ProductRepository productRepository, BlogsRepository blogsRepository, ProductTypeRepository productTypeRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }
        public IActionResult Index()
        {
            var ProductList = _productRepository.GetAll();
            ViewBag.ProductTypes = _productTypeRepository.GetAll();
            return View(ProductList);
        }

        public IActionResult Detail(int Id)
        {
            var Product= _productRepository.GetById(Id);
            return View(Product);
        }

    }
}
