using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Data
{
    [Table("Authors")]
    public class Author
    {

        public int Id { get; set; }

    
        [Required]
        public string firstName { get; set; }
        [Required]

        public string lastName { get; set; }


        public string path { get; set; }


        [NotMapped]

        public IFormFile Image { get; set; }



        [ForeignKey("nationality_fk")]
        public int Nationality_id { get; set; }

        public int nationality { get; set; }

        public List<Book> liBook { get; set; }
    }
}
