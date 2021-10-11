using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCamp.Controllers
{
    public class AboutController : Controller
    {

        AboutManager abm = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult SocialMediaAbout()
        {
            var values = abm.GetList();
            return PartialView(values);
        }
    }
}
