using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Controllers
{
    public class HelpSiteController : Controller
    {
        public IActionResult HelpSiteView()
        {
            return View();
        }
    }
}
