using BookWeb.Data;
using BookWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookWeb.Controllers
{
    public class UserReadedBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserReadedBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ReadedBooks()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userReadedBooks = _context.ReadedBooks
                .Include(ufb => ufb.book)
                    .ThenInclude(b => b.Author)
                .Include(ufb => ufb.book)
                    .ThenInclude(b => b.Category)
                .Include(ufb => ufb.book)
                    .ThenInclude(b => b.ratings)
                        .ThenInclude(r => r.User)
                .Where(ufb => ufb.UserId == user);

            var model = userReadedBooks.Select(ufb => new BookDetailsViewModel
            {
                book = ufb.book,
                author = ufb.book.Author,
                category = ufb.book.Category,
                bookRating = ufb.book.ratings.FirstOrDefault(r => r.UserId == user)
            }).ToList();

            return View(model);
        }

        public IActionResult RemoveFromReadedList(int bookId)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userReadedBooks = _context.ReadedBooks
                .FirstOrDefault(ufb => ufb.UserId == user && ufb.BookId == bookId);

            if (userReadedBooks != null)
            {
                _context.ReadedBooks.Remove(userReadedBooks);
                _context.SaveChanges();
                TempData["success"] = "The book was successfully removed from the list";
            }

            return RedirectToAction("ReadedBooks");
        }
    }
}
