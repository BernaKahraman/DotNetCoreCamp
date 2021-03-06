using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCamp.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        Context c = new Context();
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBM(writerId);  //Kategorinin id yerine adının getirilmesi için 
            return View(values);

        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,    //Blogların categorisini dropdowndan seçmek için 
                                                       Value = x.CategoryID.ToString()  //Kullanıcı kategori adını seçicek ama arkada id göre getirilecek
                                                   }).ToList();   // listesini getir 
            ViewBag.cv = categoryvalues;  //viewbag komutuyla category valuesdan gelen değerleri dropdowna taşıcak
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p) //blog sınıfından bir p parametresi 
        {
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerId;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            //silme işleminin yapılabilmesi için ilgili değerin bulunması gerekiyor
            var blogvalue = bm.TGetByID(id);  //göndermiş olduğum id karşılık gelen satırın tamamını bulacak 
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            //güncellenecek işlemi buraya çağırmalıyız
            var blogvalue = bm.TGetByID(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,    //dropdowna categori gelsin diye
                                                       Value = x.CategoryID.ToString() 
                                                   }).ToList();   
            ViewBag.cv = categoryvalues;  
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            //her bölüm için düzenleme işlemi yapmadığımızda ya null dönüyor ya da default bir şey o nedenle bu kodları yazdık
            p.WriterID = writerId;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());   //düzenleme yapıldığında o günün tarihi gelsin
            p.BlogStatus = true; //düzenleme yapıldığında durumu true olsun diye yazdık(yazmadığımızda false dönüyor)
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");

        }
    }
}
