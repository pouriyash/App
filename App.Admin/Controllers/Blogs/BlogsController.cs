using Alamut.Data.Structure;
using App.Admin.Helpers;
using App.Common.Extentions;
using App.DomainModels.Dto.Blogs;
using App.DomainModels.SSOT;
using App.DomainModels.ViewModels.Blogs;
using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace App.Admin.Controllers
{
    [Authorize]
    public class BlogsController : Controller
    {
        private readonly BlogsRepository _blogsRepository;
        private readonly BlogGalleryRepository _blogGalleryRepository;
        private readonly FileConfig _fileConfig;
        private readonly IHostingEnvironment _environment;

        public BlogsController(BlogsRepository blogsRepository
            , BlogGalleryRepository blogGalleryRepository
            , IHostingEnvironment environment
            , FileConfig fileConfig)
        {
            _fileConfig = fileConfig;
            _blogGalleryRepository = blogGalleryRepository;
            _environment = environment;
            _blogsRepository = blogsRepository;
        }

        public IActionResult Index()
        {
            var model = _blogsRepository.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogsDTO model, IFormFile Image)
        {
            var imageName = FileHelper.SaveFile(Image, _fileConfig, FileType.Image,_environment.WebRootPath);
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
                TempData.AddResult(ServiceResult.Error("مقاله ای یافت نشد!"));
                return View(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BlogsViewModel model, int Id, IFormFile NewImage)
        {

            if (NewImage != null)
            {
                var imageName = FileHelper.SaveFile(NewImage, _fileConfig, FileType.Image, _environment.WebRootPath);
                //FileHelper.DeleteFile(model.Image, _fileConfig, FileType.Image, _environment.WebRootPath);
                model.Image = imageName;
            }

            var result = _blogsRepository.Edit(model, Id);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id, string ImagePath)
        {
            var result = _blogsRepository.Delete(Id);
            if (result.Succeed)
                _blogGalleryRepository.DeleteByBlogId(Id);
                //FileHelper.DeleteFile(ImagePath, _fileConfig, FileType.Image, _environment.WebRootPath);

            TempData.AddResult(result);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult View(int Id)
        {
            var result = _blogsRepository.Delete(Id);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult BlogDetail(int Id)
        {
            var result = _blogsRepository.GetById(Id);
            return View(result);
        }
    }
}