using Microsoft.AspNetCore.Mvc;
using SoruCevapPortal.MVC.Models;
using System.Diagnostics;

namespace SoruCevapPortal.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AskQuestion()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult QuestionDetail(int id)
        {

            ViewBag.QuestionId = id;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult EditQuestion(int id)
        {
            ViewBag.QuestionId = id;
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
