using BookWeb.Data;
using BookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<User> objUsersList = _db.users;
            return View(objUsersList);
        }
        public IActionResult CreateUser() {
			return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult CreateUser(User obj)
		{
            _db.users.Add(obj);
            _db.SaveChanges();
			return RedirectToAction("Index", "Home");
		}
	}
}
