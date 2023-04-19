using BookWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace BookWeb.ViewModels
{
    public class BookDetailsViewModel
    {
        public Book? book { get; set; } = new Book();
        public Category? category { get; set; } = new Category();
        public Author? author { get; set; } = new Author();
        public BookRate? bookRating { get; set; } = new BookRate();
        public List<Comment>? comments { get; set; } = new List<Comment>();

    }
}
