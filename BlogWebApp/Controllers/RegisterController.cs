using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApp.Controllers
{
    public class RegisterController : Controller
    {
        //Ekleme işlemi yapılırken httpget ve httppost attribütlerinin tanımlandığı methodların 
        //isimleri aynı olmak zorundadır.
        //HttpGet => Sayfa yüklenirken -----------
        //mesela httpget attribute komutu sayfada kategorilize veya benzeri işlemlerkullanılırken
        // sayfa yüklendiği anda listelenmesi istenen niteliklerde kullanılabilir.

        //HttpPost => Sayfada buton tetiklediğinde 

        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {

            //Fluent Validation işlemleri - yazar kayıt kısmı için.
            WriterValidator wv = new WriterValidator();
            ValidationResult result = wv.Validate(p);
            if (result.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Blog");

            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}
