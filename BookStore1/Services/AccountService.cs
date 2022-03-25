using BookStore1.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Services
{
    public class AccountService : IAccountService
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<IdentityRole> roleManager;

        public AccountService(UserManager<ApplicationUser> _UserManager,
            SignInManager<ApplicationUser> _signInManager,
            RoleManager<IdentityRole> _roleManager
            )
        {
            userManager = _UserManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        public async Task<IdentityResult> Create(SignUpModel model)
        {
            ApplicationUser user = new ApplicationUser();
            user.Email = model.Email;
            user.Name = model.Name;
            user.UserName = model.Username;

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var role = await roleManager.FindByIdAsync(model.Role_Id);

                result = await userManager.AddToRoleAsync(user, role.Name);

            }

            return result;
        }

        public async Task<SignInResult> SignIn(SignInModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.rememberMe, false);
            return result;
        }

        public async Task<IdentityResult> AddRole(RoleModel model)
        {
            IdentityRole role = new IdentityRole();
            role.Name = model.Name;

            var result = await roleManager.CreateAsync(role);
            return result;
        }

        public List<IdentityRole> GetRole()
        {
            List<IdentityRole> liRole = roleManager.Roles.ToList();
            return liRole;
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }



    }
}
