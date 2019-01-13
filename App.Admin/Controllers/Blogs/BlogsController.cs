using Alamut.Data.Structure;
using App.Admin.Helpers;
using App.Common.Extentions;
using App.DomainModels.Dto.Blogs;
using App.DomainModels.SSOT;
using App.DomainModels.ViewModels.Blogs;
using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Linq;

namespace App.Admin.Controllers
{
    [Authorize]
    public class BlogsController : Controller
    {
        private readonly BlogsRepository _blogsRepository;
        private readonly IOptionsSnapshot<FileConfig> _fileConfig;

        public BlogsController
           (BlogsRepository blogsRepository, IOptionsSnapshot<FileConfig> fileConfig)
        {
            _fileConfig = fileConfig;
            _blogsRepository = blogsRepository;
        }

        public IActionResult Index()
        {
            var model = _blogsRepository.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            var ProductTypes = _blogsRepository.GetAll().Select(x => new { x.Id, Value = x.Title });

 
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogsDTO model, IFormFile Image)
        {
            var imageName = FileHelper.SaveFile(Image, _fileConfig, FileType.Image);
            if (imageName != null)
                model.Image = imageName;
            var result = _blogsRepository.Create(model);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            var model = _blogsRepository.GetById(Id);
            if (model == null)
            {
                TempData.AddResult(ServiceResult.Error("نوعی یافت نشد!"));
                return View(nameof(Index));
            }
            var ProductTypes = _blogsRepository.GetAll().Select(x => new { x.Id, Value = x.Title });

            ViewBag.ProductTypes = new SelectList(ProductTypes, "Id", "Value");

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BlogsViewModel model, int Id, IFormFile Image)
        {
            var imageName = FileHelper.SaveFile(Image, _fileConfig, FileType.Image);
            if (imageName != null)
                model.Image = imageName;
            var result = _blogsRepository.Edit(model, Id);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Edit), new { Id });
        }


        public IActionResult Delete(int Id)
        {
            var result = _blogsRepository.Delete(Id);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Index));
        }

        //public IActionResult View(int Id)
        //{
        //    var result = _productRepository.Delete(Id);
        //    TempData.AddResult(result);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}