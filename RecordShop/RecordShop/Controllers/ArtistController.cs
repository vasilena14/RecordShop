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
    public class ArtistController : Controller
    {
        private readonly RecordShopDbContext _db;
        public ArtistController(RecordShopDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View(_db.Artists.ToList());
        }

        //HTTP Get Method
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _db.Add(artist);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        //Post Method
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Artist artist = _db.Artists.Find(id);
            if (artist == null)
            {
                return NotFound();
            }
            _db.Artists.Remove(artist);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var artist = _db.Artists.Find(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        [HttpPost]
        public IActionResult Edit(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _db.Artists.Update(artist);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }
    }
}
