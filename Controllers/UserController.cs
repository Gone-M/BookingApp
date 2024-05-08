using booking.Models;
using Microsoft.AspNetCore.Mvc;

namespace User.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public IActionResult CreateUser(UserModel userModel)
        {
            return RedirectToAction("UserSuccess");
        }

        public IActionResult UserSuccess()
        {
            return View();
        }
    }
}
