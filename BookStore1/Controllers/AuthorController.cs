using BookStore1.Data;
using BookStore1.Models;
using BookStore1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Controllers
{
    public class AuthorController : Controller
    {
        private IConfiguration Configuration;
        IAuthorService authorService;
        INationality nationalityService;

        public AuthorController(IConfiguration _configuration, IAuthorService _author, INationality _nationality)
        {
            Configuration = _configuration;
            authorService = _author;
            nationalityService = _nationality;
        }
        [Authorize]
        public IActionResult Index()
        {

            AuthorVM vm = new AuthorVM();
            vm.author = new Author();
            List<Nationality> national = nationalityService.Load();
            List<Author> author = authorService.Load();
            vm.liNationalities = national;
            vm.liAuthor = author;
            return View("AuthorPage", vm);
        }

        public IActionResult saveData(AuthorVM vm)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), Configuration["Filepath"], vm.author.Image.FileName);
            vm.author.Image.CopyTo(new FileStream(path, FileMode.Create));
            vm.author.path = "http://localhost/bookProject1/img/" + vm.author.Image.FileName;
            List<Nationality> national = nationalityService.Load();
            authorService.Insert(vm.author);
            List<Author> author = authorService.Load();
            vm.liNationalities = national;
            vm.liAuthor = author;

            return View("AuthorPage", vm);
        }
        public IActionResult Search(AuthorVM vm)
        {
            string name = Request.Form["searchAuthor"];
            List<Author> liauthor = authorService.LoadAuthorByName(name);
            List<Nationality> national = nationalityService.Load();
            vm.liNationalities = national;
            vm.liAuthor = liauthor;
            return View("AuthorPage", vm);
        }

        // I put it in the Ajax Controller because it didn't work properly

        //public IActionResult Edit(int id)
        //{
        //    AuthorVM vm = new AuthorVM();
        //    Author author = authorService.Load(id);
        //    List<Author> liauthor = authorService.Load();
        //    List<Nationality> national = nationalityService.Load();
        //    vm.liNationalities = national;
        //    vm.liAuthor = liauthor;
        //    vm.author = author;
        //    // return View("AuthorPage", vm);
        //    return Json(vm);
        //}

        public IActionResult Update(AuthorVM vm)
        {
            authorService.Update(vm.author);
            List<Author> liauthor = authorService.Load();
            List<Nationality> national = nationalityService.Load();
            vm.liNationalities = national;
            vm.liAuthor = liauthor;
            return View("AuthorPage", vm);
        }

        public IActionResult Delete(int id)
        {
            AuthorVM vm = new AuthorVM();
            vm.author = new Author();
            List<Author> liauthor = new List<Author>();
            List<Nationality> national = nationalityService.Load();
            vm.liNationalities = national;
            vm.liAuthor = liauthor;
            authorService.Delete(id);
            return View("AuthorPage", vm);
        }
    }
}
