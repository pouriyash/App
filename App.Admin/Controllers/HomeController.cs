using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Controllers
{
    [Route("Home")]
    public class HomeController
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Person> _person;
        public HomeController(AppDbContext uow)
        {
            _uow = uow;
            _person = _uow.Set<Person>();
        }
        //[ActionContext]
        //public ActionContext ActionContext { get; set; }
        //public HttpContext HttpContext => ActionContext.HttpContext;
        [Route("")]
        public string hello()
        {

           var model= _person.ToList();
            return "Running a POCO controller!";
        }
    }
}