using BookStore1.Data;
using BookStore1.Models;
using BookStore1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BookStore1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AjaxController : ControllerBase
    {
        BookContext context;
       

        public AjaxController(BookContext _context)
        {
            context = _context;
        }

        public string EditBook(int id)
        {
           
            BookVM vm = new BookVM();
            Book Book = context.book.FirstOrDefault(x => x.id == id);
            Category Cat = context.category.FirstOrDefault(x => x.Id == Book.Categoy_id);
            Author author = context.author.FirstOrDefault(x => x.Id == Book.Author_id);
            vm.book = Book;
            vm.category = Cat;
            vm.author = author;
            string jsonString = JsonConvert.SerializeObject(vm,new JsonSerializerSettings { NullValueHandling=NullValueHandling.Ignore,ReferenceLoopHandling=ReferenceLoopHandling.Ignore});

            return (jsonString);
           
        } 
        public string EditAuthor(int id)
        {

            AuthorVM vm = new AuthorVM();
            Author author = context.author.FirstOrDefault(x => x.Id == id);
            vm.author = author;
            string jsonString = JsonConvert.SerializeObject(vm,new JsonSerializerSettings { NullValueHandling=NullValueHandling.Ignore,ReferenceLoopHandling=ReferenceLoopHandling.Ignore});

            return (jsonString);  
        }
        public string EditCategory(int id)
        {

            CategoryVM vm = new CategoryVM();
  
            Category Cat = context.category.FirstOrDefault(x => x.Id == id);
            vm.Category = Cat;
            string jsonString = JsonConvert.SerializeObject(vm, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            return (jsonString);

        }
    }
}
