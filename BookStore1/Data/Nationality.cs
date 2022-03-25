using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BookStore1.Data
{
    [Table("Nationalitys")]
    public class Nationality
    {


        public int Id { get; set; }


        public string Name { get; set; }


        public List<Author> liAuthor { get; set; }

    }
}
