using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public IActionResult FillOutBowlerForm()
        {
            ViewBag.Teams = _context.Teams.ToList();

            return View("BowlerForm");
        }

        [HttpPost]
        public IActionResult FillOutBowlerForm(Bowler ar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ar);
                _context.SaveChanges();

                return View("Home", ar);
            }
            else
            {
                ViewBag.Teams = _context.Teams.ToList();

                return View(ar);
            }

        }



        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Teams = _context.Teams.ToList();

            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("BowlerForm", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler bowler)
        {
            _context.Update(bowler);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View(bowler);
        }
        [HttpPost]
        public IActionResult Delete(Bowler ar)
        {
            _context.Bowlers.Remove(ar);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
