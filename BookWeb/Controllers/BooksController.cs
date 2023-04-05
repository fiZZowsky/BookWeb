using BookWeb.Data;
using BookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using static System.Reflection.Metadata.BlobBuilder;

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

    //public IActionResult Index(int? categoryId, string sortOrder)
    //{
    //    var categories = _context.Categories.ToList();
    //    var books = _context.Books.Include(b => b.Category).ToList();
    //    var authors = _context.Authors.ToList();

    //    if (categoryId.HasValue)
    //    {
    //        ViewBag.TitleSortParam = String.IsNullOrEmpty(sortOrder) ? "Title A-Z" : "";
    //        ViewBag.AddDateSortParam = sortOrder == "releaseDate" ? "Release Date" : "";
    //        switch (sortOrder)
    //        {
    //            case "Title A-Z":
    //                books = books.OrderBy(b => b.Title).Where(b => b.CategoryId == categoryId.Value).ToList();
    //                break;
    //            case "Title Z-A":
    //                books = books.OrderByDescending(b => b.Title).Where(b => b.CategoryId == categoryId.Value).ToList();
    //                break;
    //            case "Release Date":
    //                books = books.OrderBy(b => b.ReleaseDate).Where(b => b.CategoryId == categoryId.Value).ToList();
    //                break;
    //            default:
    //                books = books.OrderBy(b => b.Title).ToList();
    //                break;
    //        }


    //        var model = new Tuple<IEnumerable<Category>, IEnumerable<Book>>(categories, books);

    //        return View(model);
    //    }
    //}
}