using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    [Route("Home")]
    public class HomeController
    {
        private readonly AppDbContext _ctx;
        public HomeController(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        //[ActionContext]
        //public ActionContext ActionContext { get; set; }
        //public HttpContext HttpContext => ActionContext.HttpContext;
        [Route("")]
        public string hello()
        {

           var model= _ctx.Person.ToList();
            return "Running a POCO controller!";
        }
    }
}