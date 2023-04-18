using BookWeb.Data;
using BookWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookWeb.Controllers
{
    public class BooksToReadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksToReadController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult UserBooksToRead()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userBookToRead = _context.BooksToReads
                .Include(ufb => ufb.book)
                    .ThenInclude(b => b.Author)
                .Include(ufb => ufb.book)
                    .ThenInclude(b => b.Category)
                .Include(ufb => ufb.book)
                    .ThenInclude(b => b.ratings)
                        .ThenInclude(r => r.User)
                .Where(ufb => ufb.UserId == user);

            var model = userBookToRead.Select(ufb => new BookDetailsViewModel
            {
                book = ufb.book,
                author = ufb.book.Author,
                category = ufb.book.Category,
                bookRating = ufb.book.ratings.FirstOrDefault(r => r.UserId == user)
            }).ToList();

            return View(model);
        }

        public IActionResult RemoveFromToReadList(int bookId)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userBookToRead = _context.BooksToReads
                .FirstOrDefault(ufb => ufb.UserId == user && ufb.BookId == bookId);

            if (userBookToRead != null)
            {
                _context.BooksToReads.Remove(userBookToRead);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(UserBooksToRead));
        }
    }
}
