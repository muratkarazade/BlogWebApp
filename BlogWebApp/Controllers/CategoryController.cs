using Microsoft.AspNetCore.Mvc;

namespace BlogWebApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
