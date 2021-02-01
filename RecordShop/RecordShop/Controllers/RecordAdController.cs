using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecordShop.AppDbContext;
using RecordShop.Helpers;
using RecordShop.Models;
using RecordShop.Models.ViewModels;

namespace RecordShop.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
    public class RecordAdController : Controller
    {
        private readonly RecordShopDbContext _db;

        [BindProperty]
        public RecordAdViewModel RecordAdVM { get; set; }

        public RecordAdController(RecordShopDbContext db)
        {
            _db = db;
            RecordAdVM = new RecordAdViewModel()
            {
                Artists = _db.Artists.ToList(),
                Albums = _db.Albums.ToList(),
                RecordAd = new Models.RecordAd()
            };
        }

        public IActionResult Index()
        {
            var RecordAds = _db.RecordAds.Include(m => m.Artist).Include(m => m.Album);
            return View(RecordAds.ToList());
        }

        //Get Method
        public IActionResult Create()
        {
            return View(RecordAdVM);
        }

        //Post Method
        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(RecordAdVM);
            }
            _db.RecordAds.Add(RecordAdVM.RecordAd);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //public IActionResult Edit(int id)
        //{
        //    AlbumVM.Album = _db.Albums.Include(m => m.Artist).SingleOrDefault(m => m.Id == id);
        //    if (AlbumVM.Album == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(AlbumVM);
        //}

        //[HttpPost, ActionName("Edit")]
        //public IActionResult EditPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(AlbumVM);
        //    }
        //    _db.Update(AlbumVM.Album);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    Album album = _db.Albums.Find(id);
        //    if (album == null)
        //    {
        //        return NotFound();
        //    }
        //    _db.Albums.Remove(album);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
