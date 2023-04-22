using System.Linq;
using System.Security.Claims;
using BookWeb.Data;
using BookWeb.Models;
using BookWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Controllers
{
    [Authorize]
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
            var userBooksToRead = _context.BooksToReads
                .Include(ufb => ufb.book)
                    .ThenInclude(b => b.Author)
                .Include(ufb => ufb.book)
                    .ThenInclude(b => b.Category)
                .Include(ufb => ufb.book)
                    .ThenInclude(b => b.ratings)
                        .ThenInclude(r => r.User)
                .Where(ufb => ufb.UserId == user);

            var model = userBooksToRead.Select(ufb => new BookDetailsViewModel
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
            var userBooksToRead = _context.BooksToReads
                .FirstOrDefault(ufb => ufb.UserId == user && ufb.BookId == bookId);

            if (userBooksToRead != null)
            {
                _context.BooksToReads.Remove(userBooksToRead);
                _context.SaveChanges();
                TempData["success"] = "The book was successfully removed from the list";
            }

            return RedirectToAction("UserBooksToRead");
        }

    }
}