using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // Temporary in-memory user list
        private static List<User> _users = new List<User>();

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Check if username already exists
                if (_users.Any(u => u.Username == model.Username))
                {
                    ViewBag.Message = "Username already exists";
                    ViewBag.IsSuccess = false;
                    return View();
                }

                _users.Add(model);
                // Show success message
                ViewBag.Message = "Registration successful!";
                ViewBag.IsSuccess = true;   // Flag to style message
                return View();
            }
            ViewBag.IsSuccess = false;
            return View();
        }


        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                // Store username in session
                HttpContext.Session.SetString("Username", user.Username);
                ViewBag.Username = user.Username;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Invalid username or password";
            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index", "Home");
        }
    }
}
