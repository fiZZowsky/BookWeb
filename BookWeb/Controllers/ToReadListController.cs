using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Controllers
{
    public class ToReadListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
