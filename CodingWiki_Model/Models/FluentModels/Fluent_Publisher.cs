using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    public class Fluent_Publisher
    {
        //[Key]
        public int Publisher_Id { get; set; }
        //[Required]
        public string Name { get; set; }
        public string Location { get; set; }
        //Navigation property to retrieve all books by a publisher.
        public List<Fluent_Book> Books { get; set; }
    }
}
