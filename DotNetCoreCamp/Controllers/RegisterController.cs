using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        public IActionResult Index(Writer writer, string WriterPasswordAgain)
        {
            //ekleme işlemi yapılırken, hhtpget ve http post attributelerinin tanımlandığı metotların 
            //isimleri aynı olmak zorundadır.

            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(writer);
            if (results.IsValid && writer.WriterPassword == WriterPasswordAgain)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme";
                wm.WriterAdd(writer);
                return RedirectToAction("Index", "Blog");
            }
            else if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            else
            {
                ModelState.AddModelError("WriterPassword", "Şifreler Eşleşmedi Lütfen Tekrar Deneyin!");
            }
            return View();
        }
           


        }
    }

