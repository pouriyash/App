﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    [Authorize]
    public class BlogsController : Controller
    {
        public BlogsController
           ()

        {

        }

    }
}