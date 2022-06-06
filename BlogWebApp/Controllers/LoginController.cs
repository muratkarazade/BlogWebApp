using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index(Writer p)
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x=>x.WriterMail == p.WriterMail && 
            x.WriterPassword == p.WriterPassword);
            if(datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , p.WriterMail)
                };
                var useridentity = new ClaimsIdentity(claims , "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Blog");   
            }
            else
            {
                return View();
            }
           
        }
    }
}

//Context c = new Context();
//var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail ==
//    p.WriterMail && x.WriterPassword == p.WriterPassword);

//if (datavalue != null)
//{
//    HttpContext.Session.SetString("username", p.WriterMail);
//    return RedirectToAction("Index", "Writer");
//}
//else
//{
//    return View();
//}
