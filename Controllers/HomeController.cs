using System;
using Microsoft.AspNetCore.Mvc;
using booking.Models;
using booking.Data;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;



namespace Civan.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly BookingDbContext _context;

        public HomeController(BookingDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
            {
                return View();
            }

            public IActionResult English()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Logout()
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Index", "Home");
            }

        private bool IsValidUser(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user != null;
        }

        [HttpGet]
            public IActionResult SignIn()
            {
                return View("SignIn");
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> SignIn(string email, string password)
            {
                if (IsValidUser(email, password))
                {
                    var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, email),
        };
                    var userIdentity = new ClaimsIdentity(claims, "login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    return View();
                }
            }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                _context.SaveChanges();

                return RedirectToAction("SignIn");
            }

            return View(model);
        }

        public IActionResult Register()
        {
            var model = new UserModel();
            return View(model);
        }

        public IActionResult Forgot()
        {
            return View();
        }

        public IActionResult Account()
        {
            var userEmail = HttpContext.User.Identity.Name;

            UserModel user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            return View(user);
        }


    }
}


