using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NekocakeApp.ViewModels;

namespace NekocakeApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                    return RedirectToAction("List", "Pie");
            }
            ModelState.AddModelError("", "User not found");
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = loginViewModel.UserName
                };

                var result = await _userManager.CreateAsync(user, loginViewModel.Password);
                if (result.Succeeded)
                {
                   return RedirectToAction("List", "Pie");
                }
                ModelState.AddModelError("", result.Errors.First().Description);
            }
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("List", "Pie");
        }
    }
}