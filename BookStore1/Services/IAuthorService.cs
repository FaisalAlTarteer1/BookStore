using BookStore1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Services
{
    public interface IAuthorService
    {
        List<Author> Load();
        void Insert(Author author);
        List<Author> LoadAuthorByName(string name);
        //Author Load(int id);
        void Update(Author author);
        void Delete(int id);

    }
}
