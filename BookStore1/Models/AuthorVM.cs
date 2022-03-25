using BookStore1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Models
{
    public class AuthorVM
    {

        public Author author { get; set; }
        public List<Author> liAuthor { get; set; }
        public List<Nationality> liNationalities { get; set; }
    }
}
