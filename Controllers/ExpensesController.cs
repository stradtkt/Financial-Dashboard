﻿using Dashboard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Controllers
{
    public class ExpensesController : Controller
    {
        private DashboardContext _context;
        public ExpensesController(DashboardContext context)
        {
            _context = context;
        }
        private User ActiveUser
        {
            get
            {
                return _context.Users.Where(u => u.UserId == HttpContext.Session.GetInt32("UserId")).FirstOrDefault();
            }
        }
        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("LoginPage", "Users");
            }
            ViewBag.TheUser = ActiveUser;
            return View();
        }
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("LoginPage", "Users");
            }
            ViewBag.TheUser = ActiveUser;
            return View();
        }
    }
}
