using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWeb.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public string CoverBookImg { get; set; }
        public int Rating { get; set; }

        /*Relationships*/
        //Author
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        //Category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        //Comment
        public ICollection<Comment> Comments { get; set; }
    
        /*Rating system*/
        public int RateCount
        {
            get { return ratings.Count; }
        }
        public int RateTotal
        {
            get
            {
                return (ratings.Sum(m => m.RateValue));
            }
        }

        public virtual ICollection<BookRate> ratings { get; set; }  
    }
}
