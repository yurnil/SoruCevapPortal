using Microsoft.AspNetCore.Mvc;

namespace SoruCevapPortal.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }
        public IActionResult Questions()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
    }

}