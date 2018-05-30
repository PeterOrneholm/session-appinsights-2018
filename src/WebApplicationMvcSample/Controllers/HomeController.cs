using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMvcSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculator()
        {
            return View();
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpPost]
        public IActionResult About(string name)
        {
            ViewData["Name"] = name;

            return View();
        }
    }
}
