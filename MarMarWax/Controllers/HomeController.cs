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
    public class HomeController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly BlogsRepository _blogsRepository;
        public HomeController(ProductRepository productRepository, BlogsRepository blogsRepository)
        {
            _blogsRepository = blogsRepository;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            ViewBag.ProductList = _productRepository.GetAll();
            ViewBag.BlogList = _blogsRepository.GetRandom();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
