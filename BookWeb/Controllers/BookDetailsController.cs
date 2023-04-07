using BookWeb.Data;
using Microsoft.AspNetCore.Mvc;
using BookWeb.Models;
using BookWeb.ViewModels;
using Microsoft.EntityFrameworkCore;

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
            var book = _context.Books.Include(b => b.Author).Include(b => b.Category).FirstOrDefault(b => b.Id == bookId);

            var model = new BookDetailsViewModel
            {
                book = book,
                category = book.Category,
                author = book.Author
            };

            return View(model);
        }
    }
}
