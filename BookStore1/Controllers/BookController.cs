using BookStore1.Data;
using BookStore1.Models;
using BookStore1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Controllers
{
    public class BookController : Controller
    {
        private IConfiguration Configuration;
        IBookService bookService;
        ICategory categoryService;
        IAuthorService authorService;
        BookContext context;

        public BookController(IConfiguration _configuration, IBookService _bookService, ICategory _categoryService, IAuthorService _authorService, BookContext _context)
        {
            Configuration = _configuration;
            bookService = _bookService;
            categoryService = _categoryService;
            authorService = _authorService;
            context = _context;
        }

        public IActionResult Index(BookVM vm)
        {
            vm.book = new Book();
            vm.author = new Author();
            vm.category = new Category();
            Category cate = new Category();
            Author auth = new Author();

            List<Book> liBook = bookService.Load();
            List<Category> liCat = categoryService.Load();
            List<Author> liAuthor = authorService.Load();
            vm.liBook = liBook;
            vm.liCategory = liCat;
            vm.liAuthor = liAuthor;
            return View("BookPage", vm);
        }


        public IActionResult saveData(BookVM vm)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), Configuration["FilePath"], vm.book.Cover.FileName);
            vm.book.Cover.CopyTo(new FileStream(path, FileMode.Create));
            vm.book.path = "http://localhost/bookProject1/img/" + vm.book.Cover.FileName;


            List<Book> liBook = bookService.Load();
            List<Category> liCat = categoryService.Load();
            bookService.Insert(vm.book);
            List<Author> author = authorService.Load();
           
            vm.liBook = liBook;
            vm.liCategory = liCat;
            vm.liAuthor = author;
            return View("BookPage", vm);
        }

        public IActionResult Search(BookVM vm)
        {
            string name = Request.Form["searchAuthor"];
            List<Book> liBook = bookService.LoadBookByName(name);
            List<Category> liCat = categoryService.Load();
            List<Author> author = authorService.Load();
            vm.liBook = liBook;
            vm.liCategory = liCat;
            vm.liAuthor = author;
            return View("BookPage", vm);
        }

        // I put it in the Ajax Controller because it didn't work properly

        //public IActionResult Edit(int id)
        //{
        //    BookVM vm = new BookVM();
        //    Book Book = bookService.Load(id);
        //    List<Book> liBook = bookService.Load();
        //    List<Category> liCat = categoryService.Load();
        //    List<Author> author = authorService.Load();
        //    vm.liBook = liBook;
        //    vm.book = Book;
        //    vm.liCategory = liCat;
        //    vm.liAuthor = author;
        //    return Json(vm);
        //    //return View("BookPage", vm);
        //}
        public IActionResult Update(BookVM vm)
        {
            bookService.Update(vm.book);
            List<Book> liBook = bookService.Load();
            List<Category> liCat = categoryService.Load();
            List<Author> author = authorService.Load();
            vm.liBook = liBook;
            vm.liCategory = liCat;
            vm.liAuthor = author;
            return View("BookPage", vm);
        }
        public IActionResult Delete(int id)
        {
            
            BookVM vm = new BookVM();
            vm.book = new Book();
            vm.author = new Author();
            vm.category = new Category();
            List<Book> liBook = bookService.Load();
            List<Category> liCat = categoryService.Load();
            List<Author> author = authorService.Load();
            vm.liBook = liBook;
            vm.liCategory = liCat;
            vm.liAuthor = author;
            bookService.Delete(id);
            return View("BookPage", vm);
        }
    }
}
