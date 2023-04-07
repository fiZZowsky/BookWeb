using BookWeb.Data;
using Microsoft.AspNetCore.Mvc;
using BookWeb.Models;

namespace BookWeb.Controllers
{
    public class BookDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            return View();
        }
    }
}
