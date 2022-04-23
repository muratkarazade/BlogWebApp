using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
            p.WriterStatus = true;
            p.WriterAbout = "Deneme Test";
            wm.WriterAdd(p);
            return RedirectToAction("Index","Blog");
        }
    }
}
