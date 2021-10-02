using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCamp.Controllers
{
    public class RegisterController : Controller
    {

        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet] //sayfa yüklenince
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost] //Sayfada buton tetiklenince
        public IActionResult Index(Writer p)
        {
            //ekleme işlemi yapılırken, hhtpget ve http post attributelerinin tanımlandığı metotların 
            //isimleri aynı olmak zorundadır.
            p.WriterStatus = true;
            p.WriterAbout = "Deneme";
            wm.WriterAdd(p);
            return RedirectToAction("Index", "Blog");


        }
    }
}
