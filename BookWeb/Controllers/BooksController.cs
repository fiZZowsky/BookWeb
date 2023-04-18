using Azure.Core;
using BookWeb.Data;
using BookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

public class BooksController : Controller
{
    private readonly ApplicationDbContext _context;

    public BooksController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> IndexAsync(int? categoryId, string sortOrder, string searchString)
    {
        var categories = await _context.Categories.ToListAsync();
        var books = _context.Books.Include(b => b.Category).Include(b => b.Author)
            .Where(b => !categoryId.HasValue || b.CategoryId == categoryId.Value);

        if (!String.IsNullOrEmpty(searchString))
        {
            books = books.Where(s => s.Title.Contains(searchString));
        }

        switch (sortOrder)
        {
            case "Title A-Z":
                books = books.OrderBy(b => b.Title);
                break;
            case "Title Z-A":
                books = books.OrderByDescending(b => b.Title);
                break;
            case "Author A-Z":
                books = books.OrderBy(b => b.Author.Name);
                break;
            case "Release Date":
                books = books.OrderByDescending(b => b.ReleaseDate);
                break;
            default:
                break;
        }

        var booksO = await books.ToListAsync();

        var model = new Tuple<IEnumerable<Category>, IEnumerable<Book>>(categories, books);

        ViewBag.TitleSortParm = sortOrder == "Title A-Z" ? "Title Z-A" : "Title A-Z";
        ViewBag.AuthorSortParm = sortOrder == "Author A-Z" ? "Author Z-A" : "Author A-Z";
        ViewBag.ReleaseDateSortParm = sortOrder == "Release Date" ? "Oldest" : "Release Date";
        ViewBag.searchString = searchString;

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