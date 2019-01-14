using Alamut.Data.Structure;
using App.Admin.Helpers;
using App.Common.Extentions;
using App.DomainModels.SSOT;
using App.DomainModels.ViewModels;
using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    [Authorize]
    public class InfoController : Controller
    {
        private readonly InfoRepository _InfoRepository; 
        private readonly FileConfig _fileConfig;

        public InfoController
            (InfoRepository InfoRepository
            , FileConfig fileConfig )

        {
            _InfoRepository = InfoRepository;
            _fileConfig = fileConfig; 
        }

        public IActionResult Index()
        {
            var model = _InfoRepository.GetAll();
            return View(model);
        }
         
        public IActionResult Edit(int Id)
        {
            var model = _InfoRepository.GetById(Id);
            if (model == null)
            {
                TempData.AddResult(ServiceResult.Error("نوعی یافت نشد!"));
                return View(nameof(Index));
            }
  
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(InfoViewModel model, int Id)
        {
            var result = _InfoRepository.Edit(model, Id);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Edit), new { Id });
        }


        public IActionResult Delete(int Id, string ImagePath)
        {
            var result = _InfoRepository.Delete(Id);
            if (result.Succeed)
                FileHelper.DeleteFile(ImagePath, _fileConfig, FileType.Image);

            TempData.AddResult(result);
            return RedirectToAction(nameof(Index));
        }
    }
}