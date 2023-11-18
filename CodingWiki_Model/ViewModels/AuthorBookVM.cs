using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.ViewModels
{
    public class AuthorBookVM
    {
        public AuthorBookMap AuthorBook { get; set; }
        public Book Book { get; set; }
        public IEnumerable<AuthorBookMap> AuthorBookList { get; set; }  
        public IEnumerable<SelectListItem> AuthorList { get; set; }
    }
}
