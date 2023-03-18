using System.ComponentModel.DataAnnotations;

namespace BookWeb.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int AuthorId { get; set; }
        public int BookId { get; set; }
    }
}
