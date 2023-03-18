using System.ComponentModel.DataAnnotations;

namespace BookWeb.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateOnly ReleaseDate { get; set; }

        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string CategoryId { get; set; }
    }
}
