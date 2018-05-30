using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMvcSample.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
