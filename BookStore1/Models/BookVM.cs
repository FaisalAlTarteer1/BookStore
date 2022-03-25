using BookStore1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Models
{
    public class BookVM
    {
        public Book book { get; set; }
        public List<Book> liBook { get; set; }
        public Author author { get; set; }
        public List<Author> liAuthor { get; set; }
        public Category category { get; set; }
        public List<Category> liCategory { get; set; }
    }
}
