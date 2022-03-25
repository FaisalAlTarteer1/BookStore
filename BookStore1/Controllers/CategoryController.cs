using BookStore1.Data;
using BookStore1.Models;
using BookStore1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Controllers
{
    public class CategoryController : Controller
    {
        ICategory categoryService;

        public CategoryController(ICategory categoryService)
        {
            this.categoryService = categoryService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index(CategoryVM vm)
        {
            vm.Category = new Category();
            List<Category> cat = categoryService.Load();
            vm.liCategory = cat;
            return View("CategoryPage", vm);
        }
        public IActionResult saveData(CategoryVM vm)
        {
            categoryService.Insert(vm.Category);
            List<Category> cat = categoryService.Load();
            vm.liCategory = cat;
            return View("CategoryPage", vm);
        }

        public IActionResult Search(CategoryVM vm)
        {
            string name = Request.Form["searchCategory"];
            List<Category> licategory = categoryService.LoadCategoryByName(name);
            List<Category> cat = categoryService.Load();
            vm.liCategory = cat;

            vm.liCategory = licategory;
            return View("CategoryPage", vm);
        }

        // I put it in the Ajax Controller because it didn't work properly

        //public IActionResult Edit(int id)
        //{
        //    CategoryVM vm = new CategoryVM();
        //    Category category = categoryService.Load(id);
        //    List<Category> cat = categoryService.Load();
        //    vm.liCategory = cat;
        //    vm.Category = category;
        //    return View("CategoryPage", vm);
        //}
        public IActionResult Update(CategoryVM vm)
        {
            categoryService.Update(vm.Category);
            List<Category> cat = categoryService.Load();
            vm.liCategory = cat;
            return View("CategoryPage", vm);
        }
        public IActionResult DeleteCategory(int id)
        {
            CategoryVM vm = new CategoryVM();
            vm.Category = new Category();
            List<Category> licategory = new List<Category>();
            vm.liCategory = licategory;
            categoryService.Delete(id);
            return View("CategoryPage", vm);
        }
    }
}
