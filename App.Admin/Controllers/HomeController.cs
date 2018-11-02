using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Models;
using App.DomainServices.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Controllers
{
    [Route("Home")]
    public class HomeController
    {
        private readonly PersonRepository _personrepository;
        public HomeController
            ( PersonRepository personrepository)
        {
            _personrepository = personrepository;
        }
        //[ActionContext]
        //public ActionContext ActionContext { get; set; }
        //public HttpContext HttpContext => ActionContext.HttpContext;
        [Route("")]
        public string hello()
        {

           var model= _personrepository.GetAlla();
            return "Running a POCO controller!";
        }
    }
}