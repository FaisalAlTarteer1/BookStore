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
    public class AccountController : Controller
    {
        IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        public IActionResult Index()
        {
            vmSignUp vm = new vmSignUp();
            vm.liRole = accountService.GetRole();
            return View("SignUp", vm);
        }

        public async Task<IActionResult> SignUp(vmSignUp model)
        {
            vmSignUp vm = new vmSignUp();
            vm.liRole = accountService.GetRole();
            var result = await accountService.Create(model.signUp);
            return View("SignUp", vm);
        }

        public IActionResult SignIn()
        {
            return View("SignIn");
        }

        public async Task<IActionResult> Login(SignInModel model)
        {
            var result = await accountService.SignIn(model);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Author");
            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid Username or Password";
                return View("SignIn");
            }
        }
        [Authorize]
        public IActionResult Role()
        {
            return View("NewRole");
        }

        public async Task<IActionResult> NewRole(RoleModel model)
        {
            var result = await accountService.AddRole(model);

            return View("NewRole");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await accountService.Logout();
            return View("SignIn");
        }
    }
}
