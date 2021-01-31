using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecordShop.AppDbContext;
using RecordShop.Models;
using RecordShop.Models.ViewModels;

namespace RecordShop.Controllers
{
    public class AlbumController : Controller
    {
        private readonly RecordShopDbContext _db;

        [BindProperty]
        public AlbumViewModel AlbumVM { get; set; }

        public AlbumController(RecordShopDbContext db)
        {
            _db = db;
            AlbumVM = new AlbumViewModel()
            {
                Artists = _db.Artists.ToList(),
                Album = new Models.Album()
            };
        }

        public IActionResult Index()
        {
            var album = _db.Albums.Include(m => m.Artist);
            return View(album.ToList());
        }

        //HTTPGET
        public IActionResult Create()
        {
            return View(AlbumVM);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(AlbumVM);
            }
            _db.Add(AlbumVM.Album);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            AlbumVM.Album = _db.Albums.Include(m => m.Artist).SingleOrDefault(m => m.Id == id);
            if (AlbumVM.Album == null)
            {
                return NotFound();
            }
            return View(AlbumVM);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(AlbumVM);
            }
            _db.Update(AlbumVM.Album);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Album album = _db.Albums.Find(id);
            if (album == null)
            {
                return NotFound();
            }
            _db.Albums.Remove(album);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
