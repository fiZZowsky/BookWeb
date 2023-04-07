using BookWeb.Data;
using BookWeb.Models;
using BookWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class BooksController : Controller
{
    private readonly ApplicationDbContext _context;

    public BooksController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> IndexAsync(int? categoryId, string sortOrder)
    {
        var categories = await _context.Categories.ToListAsync();
        var booksQuery = _context.Books.Include(b => b.Category).Include(b => b.Author).Where(b => !categoryId.HasValue || b.CategoryId == categoryId.Value);

        switch (sortOrder)
        {
            case "Title A-Z":
                booksQuery = booksQuery.OrderBy(b => b.Title);
                break;
            case "Title Z-A":
                booksQuery = booksQuery.OrderByDescending(b => b.Title);
                break;
            case "Author A-Z":
                booksQuery = booksQuery.OrderBy(b => b.Author.Name);
                break;
            case "Release Date":
                booksQuery = booksQuery.OrderByDescending(b => b.ReleaseDate);
                break;
            default:
                break;
        }

        var books = await booksQuery.ToListAsync();

        var model = new Tuple<IEnumerable<Category>, IEnumerable<Book>>(categories, books);

        ViewBag.TitleSortParm = sortOrder == "Title A-Z" ? "Title Z-A" : "Title A-Z";
        ViewBag.AuthorSortParm = sortOrder == "Author A-Z" ? "Author Z-A" : "Author A-Z";
        ViewBag.ReleaseDateSortParm = sortOrder == "Release Date" ? "Oldest" : "Release Date";

        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            return PartialView("_BooksByCategoryPartial", books);
        }
        else
        {
            return View(model);
        }
    }
}
