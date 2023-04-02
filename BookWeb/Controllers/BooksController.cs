using BookWeb.Data;
using BookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class BooksController : Controller
{
    private readonly ApplicationDbContext _context;

    public BooksController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(int? categoryId)
    {
        var categories = _context.Categories.ToList();
        var books = _context.Books.Include(b => b.Category).ToList();
        var authors = _context.Authors.ToList();

        if (categoryId.HasValue)
        {
            books = books.Where(b => b.CategoryId == categoryId.Value).ToList();
        }

        var model = new Tuple<IEnumerable<Category>, IEnumerable<Book>>(categories, books);

        return View(model);
    }
}