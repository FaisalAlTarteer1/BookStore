using BookStore1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Services
{
    public class categoryService:ICategory
    {
        BookContext context;
        public categoryService(BookContext _context)
        {
            context = _context;
        }

        public List<Category> Load()
        {
            List<Category> category = context.category.ToList();
            return category;
        }
        public void Insert(Category category)
        {
            context.category.Add(category);
            context.SaveChanges();
        }
        public List<Category> LoadCategoryByName(string name)
        {
            List<Category> category = context.category.Where(x => x.Name == name).ToList();
            return category;
        }

        //public Category Load(int id)
        //{
        //    Category category = context.category.Find(id);
        //    return category;
        //}
        public void Update(Category category)
        {
            context.category.Attach(category);
            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Category category = context.category.Find(id);
            context.category.Remove(category);
            context.SaveChanges();
        }
    }
}
