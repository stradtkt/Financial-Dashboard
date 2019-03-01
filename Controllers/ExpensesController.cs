using Dashboard.Models;
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
        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

    }
}
