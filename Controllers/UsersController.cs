using Dashboard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Controllers
{
    public class UsersController : Controller
    {
        private DashboardContext _context;
        public UsersController(DashboardContext context)
        {
            _context = context;
        }
        [HttpGet("login")]
        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpGet("register")]
        public IActionResult RegisterPage()
        {
            return View();
        }
        [HttpPost("login")]
        public IActionResult Login(LoginUser login)
        {
            User CheckEmail = _context.Users
               .SingleOrDefault(u => u.Email == login.Email);
            if (CheckEmail != null)
            {
                var Hasher = new PasswordHasher<User>();
                if (0 != Hasher.VerifyHashedPassword(CheckEmail, CheckEmail.Password, login.Password))
                {
                    HttpContext.Session.SetInt32("UserId", CheckEmail.UserId);
                    HttpContext.Session.SetString("FirstName", CheckEmail.FirstName);
                    return RedirectToAction("Dashboard", "Expenses");
                }
                else
                {
                    ViewBag.errors = "Incorrect Password";
                    return View("Register");
                }
            }
            else
            {
                ViewBag.errors = "Email not registered";
                return View("Register");
            }
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterUser register)
        {
            User CheckEmail = _context.Users
                .Where(u => u.Email == register.Email)
                .SingleOrDefault();
            if (CheckEmail != null)
            {
                ViewBag.errors = "That email already exists";
                return RedirectToAction("Register");
            }
            if (ModelState.IsValid)
            {
                PasswordHasher<RegisterUser> Hasher = new PasswordHasher<RegisterUser>();
                User newUser = new User
                {
                    UserId = register.UserId,
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    Email = register.Email,
                    Password = Hasher.HashPassword(register, register.Password)
                };
                _context.Add(newUser);
                _context.SaveChanges();
                ViewBag.success = "Successfully registered";
                return RedirectToAction("Login");
            }
            else
            {
                return View("Register");
            }
        }
    }
}
