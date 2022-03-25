using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookStore1.Data
{
    [Table("Books")]
    public class Book
    {
        public int id { get; set; }
        [Required]
        public string bookTitle { get; set; }
        public DateTime Year { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public string path { get; set; }
        [NotMapped]
        public IFormFile Cover { get; set; }

        [ForeignKey("category")]
        public int Categoy_id { get; set; }
        public Category category { get; set; }

        [ForeignKey("author")]
        public int Author_id { get; set; }
        public Author author { get; set; }

    }
}
