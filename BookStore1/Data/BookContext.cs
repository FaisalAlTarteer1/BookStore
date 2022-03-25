using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookStore1.Models;

namespace BookStore1.Data
{
    public class BookContext : IdentityDbContext<ApplicationUser>
    {
        IConfiguration configuration;

        public BookContext(IConfiguration _Configuration)
        {
            configuration = _Configuration;
        }
        public DbSet<Book> book { get; set; }
        public DbSet<Author> author { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Nationality> nationality { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BookConnection"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
