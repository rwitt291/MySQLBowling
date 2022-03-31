using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySQLBowling.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLBowling.Controllers
{
    public class HomeController : Controller
    {
        //private variable has an underscore
        private BowlersDbContext _context { get; set; }
        public HomeController(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            var bow = _context.Bowlers.ToList();
            return View(bow);
        }

        public IActionResult Edit ()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
