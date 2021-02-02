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
                RecordAdVM.Artists = _db.Artists.ToList();
                RecordAdVM.Albums = _db.Albums.ToList();
                return View(RecordAdVM);
            }
            _db.RecordAds.Add(RecordAdVM.RecordAd);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            RecordAdVM.RecordAd = _db.RecordAds.SingleOrDefault(m => m.Id == id);

            //Filter the albums associated to the selected artist
            RecordAdVM.Albums = _db.Albums.Where(m => m.ArtistID == RecordAdVM.RecordAd.ArtistID);
            if (RecordAdVM.RecordAd == null)
            {
                return NotFound();
            }
            return View(RecordAdVM);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                RecordAdVM.Artists = _db.Artists.ToList();
                RecordAdVM.Albums = _db.Albums.ToList();
                return View(RecordAdVM);
            }
            _db.RecordAds.Update(RecordAdVM.RecordAd);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            RecordAd recordAd = _db.RecordAds.Find(id);
            if (recordAd == null)
            {
                return NotFound();
            }
            _db.RecordAds.Remove(recordAd);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
