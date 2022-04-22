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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //public IActionResult Index()
        //{

        //}
    }
}
