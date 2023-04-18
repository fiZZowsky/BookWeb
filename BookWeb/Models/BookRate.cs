using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWeb.Models
{
    public class BookRate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, 5)]
        public int RateValue { get; set; }

        //Relationships
        //User
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }

        //Book
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book book { get; set; }
    }
}
