using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Models;
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
        private readonly PersonRepository _personrepository;
        public ProductTypesController
            (PersonRepository personrepository)

        {
            _personrepository = personrepository;
        }

        public IActionResult Index()
        {
            _personrepository.GetAlla();
            return View();
        }
    }
}