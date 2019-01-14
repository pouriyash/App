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

namespace App.Admin.Controllers
{
    [Authorize]
    public class BlogGalleryController : Controller
    {
        private readonly BlogGalleryRepository _blogGalleryRepository;
        private readonly FileConfig _fileConfig;

        public BlogGalleryController(BlogGalleryRepository blogGalleryRepository
            , FileConfig fileConfig)
        {
            _fileConfig = fileConfig;
            _blogGalleryRepository = blogGalleryRepository;
        }

        public IActionResult Index(int BlogId)
        {
            ViewBag.BlogId = BlogId;
            var model = _blogGalleryRepository.GetAll(BlogId);
            return View(model);
        }

        public IActionResult Create(int BlogId)
        {
             ViewBag.BlogId = BlogId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogGalleryDTO model, IFormFile Image)
        {
            var imageName = FileHelper.SaveFile(Image, _fileConfig, FileType.Image);
            if (imageName != null)
                model.Image = imageName;
            var result = _blogGalleryRepository.Create(model);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Index),new { model.BlogId});
        }
         
        public IActionResult Delete(int Id, string ImagePath)
        {
            var result = _blogGalleryRepository.Delete(Id);
            if (result.Succeed)
                FileHelper.DeleteFile(ImagePath, _fileConfig, FileType.Image);

            TempData.AddResult(result);
            return RedirectToAction(nameof(Index), new { result.Data });
        }
    }
}