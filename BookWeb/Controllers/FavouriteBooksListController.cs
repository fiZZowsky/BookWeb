using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Controllers
{
    public class FavouriteBooksListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
