using BookWeb.Models;

namespace BookWeb.ViewModels
{
    public class BookDetailsViewModel
    {
        public Book? book { get; set; } = new Book();
        public Category? category { get; set; } = new Category();
        public Author? author { get; set; } = new Author();
    }
}
