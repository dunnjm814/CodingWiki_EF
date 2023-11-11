using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    public class Fluent_Book
    {
       
        public int BookId { get; set; }
        public string Title { get; set; }
    
        public string ISBN { get; set; }
        public decimal Price { get; set; }
   
        public string PriceRange { get; set; }
        // BookDetail Model reference for 1-1 relationship
        public Fluent_BookDetail BookDetail { get; set; }
        //// Sets ForeignKey Relationship to the Publisher Model
        
        public int Publisher_Id { get; set; }
        // Publisher Model Reference for 1 to Many relationship
        public Fluent_Publisher Publisher { get; set; }
        public List<Fluent_AuthorBookMap> AuthorBookMap { get; set; }
    }
}
