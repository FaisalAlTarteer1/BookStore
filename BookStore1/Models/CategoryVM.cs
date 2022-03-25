using BookStore1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Models
{
    public class CategoryVM
    {
        public List<Category> liCategory { get; set; }
        public Category Category { get; set; }
    }
}
