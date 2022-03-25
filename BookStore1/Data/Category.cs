using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BookStore1.Data
{
    [Table("Categories")]
    public class Category
    {


        public int Id { get; set; }


        [Required]
        public string Code { get; set; }


        [Required]
        public string Name { get; set; }


        public List<Book> liBook { get; set; }

    }
}
