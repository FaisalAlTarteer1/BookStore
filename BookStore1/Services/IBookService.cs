using BookStore1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Services
{
    public interface IBookService
    {
        List<Book> Load();
        void Insert(Book book);
        List<Book> LoadBookByName(string name);
        //Book Load(int id);
        void Update(Book book);
        void Delete(int id);
    }
}
