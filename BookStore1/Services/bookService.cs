using BookStore1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Services
{
    public class bookService:IBookService
    {
        BookContext context;
        public bookService(BookContext _context)
        {
            context = _context;
        }
        public List<Book> Load()
        {
            List<Book> book = context.book.ToList();
            return book;
        }
        public void Insert(Book book)
        {
            context.book.Add(book);
            context.SaveChanges();
        }
        public List<Book> LoadBookByName(string name)
        {
            List<Book> book = context.book.Where(x => x.bookTitle == name).ToList();
            return book;
        }

        //public Book Load(int id)
        //{
        //    Book author = context.book.Find(id);
        //    return author;
        //}
        public void Update(Book book)
        {
            context.book.Attach(book);
            context.Entry(book).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Book book = context.book.Find(id);
            context.book.Remove(book);
            context.SaveChanges();
        }
    }
}
