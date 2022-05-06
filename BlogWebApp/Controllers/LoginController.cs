using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogWebApp.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Yazılan bu methot siteye girmiş olan yetkisiz kullanıcıların erişimini kısıtlanması için yazılmış olan
        /// Autorize işlemlerinin controller kısmı . Login sayfasına yönlendirilen ve burada mail & password 
        /// doğrulamasının yapıldığı kod bloğu.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Writer p)
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail ==
                p.WriterMail && x.WriterPassword == p.WriterPassword);

            if(datavalue != null)
            {
                HttpContext.Session.SetString("username", p.WriterMail);
                return RedirectToAction("Index" , "Writer");
            }
            else
            {
                return View();
            }

           
        }
    }
}
