using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Controllers
{
    public class HelpSiteController : Controller
    {
        public IActionResult HelpSiteView()
        {
            return View();
        }

        public IActionResult GettingStarted()
        {
            return View();
        }

        public IActionResult GetSupport()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }
    }
}
