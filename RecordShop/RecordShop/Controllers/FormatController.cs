using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecordShop.AppDbContext;
using RecordShop.Helpers;
using RecordShop.Models;

namespace RecordShop.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
    public class FormatController : Controller
    {
        private readonly RecordShopDbContext _db;
        public FormatController(RecordShopDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View(_db.Formats.ToList());
        }

        //HTTP Get Method
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Format format)
        {
            if (ModelState.IsValid)
            {
                _db.Add(format);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(format);
        }

        //Post Method
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Format format = _db.Formats.Find(id);
            if (format == null)
            {
                return NotFound();
            }
            _db.Formats.Remove(format);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var format = _db.Formats.Find(id);
            if (format == null)
            {
                return NotFound();
            }
            return View(format);
        }

        [HttpPost]
        public IActionResult Edit(Format format)
        {
            if (ModelState.IsValid)
            {
                _db.Formats.Update(format);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(format);
        }
    }
}
