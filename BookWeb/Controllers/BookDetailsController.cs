using BookWeb.Data;
using Microsoft.AspNetCore.Mvc;
using BookWeb.Models;
using BookWeb.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Net;

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
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRating = _context.BookRates.FirstOrDefault(b => b.Id == bookId && b.UserId == userID);

            var model = new BookDetailsViewModel
            {
                book = book,
                category = book.Category,
                author = book.Author,
                bookRating = userRating
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PostRating(int bid, int rating)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var bookRate = await _context.BookRates
                    .FirstOrDefaultAsync(br => br.BookId == bid && br.UserId == userID);

                if (bookRate != null)
                {
                    bookRate.RateValue = rating;
                    await _context.SaveChangesAsync();

                    TempData["success"] = "Your rating for this book has been updated.";
                }
                else
                {
                    BookRate br = new BookRate
                    {
                        RateValue = rating,
                        BookId = bid,
                        UserId = userID
                    };

                    await _context.BookRates.AddAsync(br);
                    await _context.SaveChangesAsync();

                    TempData["success"] = "You rated this " + rating.ToString() + " star(s)";
                }
            }
            else
            {
                TempData["error"] = "You must be logged in to rate this book.";
            }

            return RedirectToAction("Index", new { bid });
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorite(int bookId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!_context.UserFavorites.Any(uf => uf.UserId == userID && uf.BookId == bookId))
                {
                    var userFavoriteBook = new UserFavoriteBook { UserId = userID, BookId = bookId };
                    await _context.UserFavorites.AddAsync(userFavoriteBook);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "The book has been successfully added to your favorites list";
                }
                else
                {
                    TempData["error"] = "This book is already on your favorites list";
                }
            }
            else
            {
                TempData["error"] = "You must be logged in to add a book to your favourites";
            }

            return RedirectToAction("Index", new { bookId });
        }

        [HttpPost]
        public async Task<IActionResult> AddToReadList(int bookId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!_context.BooksToReads.Any(uf => uf.UserId == userID && uf.BookId == bookId))
                {
                    var userBookToRead = new BooksToRead { UserId = userID, BookId = bookId };
                    await _context.BooksToReads.AddAsync(userBookToRead);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "The book has been successfully added to your reading list";
                }
                else
                {
                    TempData["error"] = "This book is already on your reading list";
                }
            }
            else
            {
                TempData["error"] = "You must be logged in to add a book to your reading list";
            }
            return RedirectToAction("Index", new { bookId });
        }
        
        [HttpPost]
        public async Task<IActionResult> AddToReadedBooksList(int bookId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!_context.ReadedBooks.Any(uf => uf.UserId == userID && uf.BookId == bookId))
                {
                    var userReadedBook = new UserReadedBooks { UserId = userID, BookId = bookId };
                    await _context.ReadedBooks.AddAsync(userReadedBook);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "The book has been successfully added to your readed books list";
                }
                else
                {
                    TempData["error"] = "This book is already on your readed books list";
                }
            }
            else
            {
                TempData["error"] = "You must be logged in to add a book to your readed books list";
            }
            return RedirectToAction("Index", new { bookId });
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int bookId, string commentText)
        {
            if (User.Identity.IsAuthenticated)
            {
                var book = await _context.Books
                    .Include(b => b.Comments)
                    .FirstOrDefaultAsync(b => b.Id == bookId);

                if (book == null)
                {
                    return NotFound();
                }

                var user = await Task.Run(() => User.FindFirstValue(ClaimTypes.NameIdentifier));

                var comment = new Comment
                {
                    Content = commentText,
                    PublishedDate = DateTime.UtcNow,
                    UserId = user
                };

                book.Comments.Add(comment);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index", new { id = bookId });
            }
            else
            {
                TempData["error"] = "You must be logged in to add a comment.";
                return RedirectToAction("Index", new { id = bookId });
            }
        }
    }
}
