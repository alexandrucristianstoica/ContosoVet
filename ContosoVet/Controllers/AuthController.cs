using ContosoVet.Interfaces;
using ContosoVet.Models;
using ContosoVet.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ContosoVet.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("signup")]
        public IActionResult Signup()
        {
            var svm = new SignupViewModel();
            return View(svm);
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult Signup(Admin admin)
        {
            if (ModelState.IsValid)
            {
                _userService.CreateAdmin(admin);
                return RedirectToAction("Login");
            }
            return View(admin);
        }

        [Route("login")]
        public IActionResult Login()
        {
            var lvm = new LoginViewModel();
            return View(lvm);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                Admin admin;
                if (_userService.ValidateCredentials(lvm.Username, lvm.Password, out admin))
                {
                    await SignIn(admin);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(lvm);
        }

        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async Task SignIn(Admin admin)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, admin.Username),
                new Claim("name", admin.Name)
            };

            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme, //"cookie"
                "name",
                null);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);
        }

    }
}
