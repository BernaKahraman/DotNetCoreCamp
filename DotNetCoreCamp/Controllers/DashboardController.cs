using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCamp.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.toplamblog = c.Blogs.Count().ToString();
            ViewBag.yazarblog = c.Blogs.Where(x => x.WriterID == 1).Count();
            ViewBag.toplamkategori = c.Categories.Count();
            return View();
        }
    }
}
