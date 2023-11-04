using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        [MaxLength(20)]
        [Required]
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public string PriceRange { get; set; }
        // BookDetail Model reference for 1-1 relationship
        public BookDetail BookDetail { get; set; }
        // Sets ForeignKey Relationship to the Publisher Model
        [ForeignKey("Publisher")]
        public int Publisher_Id { get; set; }
        // Publisher Model Reference for 1 to Many relationship
        public Publisher Publisher { get; set; }
        public List<AuthorBookMap> AuthorBookMap { get; set; } 
    }
}
