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
    public class UserFavoriteBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserFavoriteBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult FavoriteBooks()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userFavBooks = _context.UserFavorites
                .Include(ufb => ufb.book)
                    .ThenInclude(b => b.Author)
                .Include(ufb => ufb.book)
                    .ThenInclude(b => b.Category)
                .Include(ufb => ufb.book)
                    .ThenInclude(b => b.ratings)
                        .ThenInclude(r => r.User)
                .Where(ufb => ufb.UserId == user);

            var model = userFavBooks.Select(ufb => new BookDetailsViewModel
            {
                book = ufb.book,
                author = ufb.book.Author,
                category = ufb.book.Category,
                bookRating = ufb.book.ratings.FirstOrDefault(r => r.UserId == user)
            }).ToList();

            return View(model);
        }

        public IActionResult RemoveFromFavorites(int bookId)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userFavBook = _context.UserFavorites
                .FirstOrDefault(ufb => ufb.UserId == user && ufb.BookId == bookId);

            if (userFavBook != null)
            {
                _context.UserFavorites.Remove(userFavBook);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(FavoriteBooks));
        }

    }
}