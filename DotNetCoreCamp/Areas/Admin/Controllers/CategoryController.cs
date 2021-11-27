﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCamp.Areas.Admin.Controllers
{
    [Area("Admin")]  //bu controllerin areadan geldiğini bildirmiş olduk
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}