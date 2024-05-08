using System;
using booking.Data;
using booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace booking.Controllers
{
    public class PagesController : Controller
    {
        private readonly BookingDbContext _context;

        public PagesController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult EditBasicInformation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBasicInformation(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(userModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(userModel);
        }
    }

}

