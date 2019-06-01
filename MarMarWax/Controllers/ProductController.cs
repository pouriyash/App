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
        private readonly ProductColorRepository _productColorRepository;
        private readonly ProductTypeRepository _productTypeRepository;
        public ProductController(ProductRepository productRepository, ProductColorRepository productColorRepository, BlogsRepository blogsRepository, ProductTypeRepository productTypeRepository)
        {
            _productRepository = productRepository;
            _productColorRepository = productColorRepository;
            _productTypeRepository = productTypeRepository;
        }
        public IActionResult Index(int ProductTypeId)
        {
            var ProductList = _productRepository.GetAllWithProductTypeId(ProductTypeId);
            ViewBag.ProductTypes = _productTypeRepository.GetAll(null);
            return View(ProductList);
        }
          public IActionResult Getall()
        {
            var ProductList = _productRepository.GetAll();
            ViewBag.ProductTypes = _productTypeRepository.GetAll(null);
            return View(ProductList);
        }

        public IActionResult ProductDetail(int Id)
        {
            var Product= _productRepository.GetById(Id);
            Product.ProductGalleryImages.Add(new App.DomainModels.Dto.Product.ProductGalleryImageDTO {
                Image = Product.Image,
                ProductId = Id
            });
            ViewBag.colors = _productColorRepository.GetAll(Id);
            return View(Product);
        }

    }
}
