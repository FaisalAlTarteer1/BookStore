using BookStore1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Services
{
    public class authorService:IAuthorService
    {
        BookContext context;
        public authorService(BookContext _context)
        {
            context = _context;
        }
        public List<Author> Load()
        {
            List<Author> author = context.author.ToList();
            return author;
        }
        public void Insert(Author author)
        {
            context.author.Add(author);
            context.SaveChanges();
        }
        public List<Author> LoadAuthorByName(string name)
        {
            List<Author> author = context.author.Where(x => x.firstName == name).ToList();
            return author;
        }

        //public Author Load(int id)
        //{
        //    Author author = context.author.Find(id);
        //    return author;
        //}
        public void Update(Author author)
        {
            context.author.Attach(author);
            context.Entry(author).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Author author = context.author.Find(id);
            context.author.Remove(author);
            context.SaveChanges();
        }
    }
}
