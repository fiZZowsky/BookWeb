using BookWeb.Models;

namespace BookWeb.ViewModels
{
    public class BookBrowserViewModel
    {
        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<Book>? Books { get; set; }

        public IEnumerable<Author>? Authors { get; set; }
    }
}
