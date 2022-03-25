using BookStore1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore1.Services
{
    public class nationalityService:INationality
    {
        BookContext context;
        public nationalityService(BookContext _context)
        {
            context = _context;
        }
        public List<Nationality> Load() 
        {
            List<Nationality> nationality = context.nationality.ToList();
            return nationality;
        }

    }
}
