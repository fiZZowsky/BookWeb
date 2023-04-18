using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWeb.Models
{
    public class UserFavoriteBook
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book book { get; set; }
    }
}
