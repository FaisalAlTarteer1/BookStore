using BookStore1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Services
{
   public interface ICategory
    {
        List<Category> Load();
        void Insert(Category category);
        List<Category> LoadCategoryByName(string name);
        //Category Load(int id);
        void Update(Category category);
        void Delete(int id);
    }
}
