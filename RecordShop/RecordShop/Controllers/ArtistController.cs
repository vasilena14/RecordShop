using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecordShop.AppDbContext;
using RecordShop.Models;

namespace RecordShop.Controllers
{
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
    }
}
