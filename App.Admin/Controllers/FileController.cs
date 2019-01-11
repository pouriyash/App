using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Admin.Helpers;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Models;
using App.DomainModels.SSOT;
using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace App.Admin.Controllers
{
    [Authorize]
    public class FileController : Controller
    {
        private readonly IOptionsSnapshot<FileConfig> _fileConfig;

        public FileController(IOptionsSnapshot<FileConfig> fileConfig)
        {
            _fileConfig = fileConfig;
        }

        public ActionResult Image(string field = "")
        {
            ViewBag.Field = field;
            return View();
        }

        [HttpPost]
        public IActionResult UploadImage(string field,IFormFile image)
        {
            ViewBag.Field = field;

            try
            {
                ViewBag.FileName = FileHelper.SaveFile(image, _fileConfig, FileType.image);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }

            return View();
        }

    }
}