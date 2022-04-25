using Microsoft.AspNetCore.Mvc;

namespace BlogWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
