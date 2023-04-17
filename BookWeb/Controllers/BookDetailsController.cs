using BookWeb.Data;
using Microsoft.AspNetCore.Mvc;
using BookWeb.Models;
using BookWeb.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BookWeb.Controllers
{
    public class BookDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int bookId, int rating, int mid)
        {
            var book = _context.Books.Include(b => b.Author).Include(b => b.Category).FirstOrDefault(b => b.Id == bookId);
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRating = _context.BookRates.FirstOrDefault(b => b.Id == bookId && b.UserId == userID);

            var model = new BookDetailsViewModel
            {
                book = book,
                category = book.Category,
                author = book.Author,
                bookRating = userRating != null ? new BookRate { RateValue = userRating.RateValue } : new BookRate()
            };

            return View(model);
        }


        [HttpPost]
        public JsonResult PostRating(int rating, int bid)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var bookRate = _context.BookRates.FirstOrDefault(br => br.BookId == bid && br.UserId == userID);

                if (bookRate != null)
                {
                    bookRate.RateValue = rating;
                    _context.SaveChanges();

                    return Json("Your rating for this book has been updated.");
                }
                else
                {
                    BookRate br = new BookRate();
                    br.RateValue = rating;
                    br.BookId = bid;
                    br.UserId = userID;

                    _context.BookRates.Add(br);
                    _context.SaveChanges();

                    return Json("You rated this " + rating.ToString() + " star(s)");
                }
            }
            else
            {
                return Json("You must be logged in to rate this book.");
            }
        }
    }
}
