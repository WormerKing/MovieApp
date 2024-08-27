using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Web.Controllers
{
    public class WormerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
