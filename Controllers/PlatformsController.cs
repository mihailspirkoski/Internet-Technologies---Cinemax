using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinemax.Models;

namespace Cinemax.Controllers
{
    public class PlatformsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Platforms
        public ActionResult Index()
        {
            return View(db.Platforms.ToList());
        }

        // start custom code
        [Authorize(Roles = "Admin")]
        public ActionResult AddAMovieToPlatform(int id)
        {
            AddToPlatform model = new AddToPlatform();
            model.selectedPlatform = id;
            model.movies = db.Movies.ToList();
            ViewBag.PlatformName = db.Platforms.Find(id).PlatformName;
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddAMovieToPlatform(AddToPlatform model)
        {
            var movie = db.Movies.Find(model.selectedMovie);
            var platform = db.Platforms.Find(model.selectedPlatform);
            platform.movies.Add(movie);
            movie.platforms.Add(platform);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteMovieFromPlatform(int id)
        {
            DeleteFromPlatform model = new DeleteFromPlatform();
            model.selectedPlatform = id;
            model.movies = db.Movies.ToList();
            ViewBag.PlatformName = db.Platforms.Find(id).PlatformName;
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeleteMovieFromPlatform(DeleteFromPlatform model)
        {
            var movie = db.Movies.Find(model.selectedMovie);
            var platform = db.Platforms.Find(model.selectedPlatform);
            platform.movies.Remove(movie);
            movie.platforms.Remove(platform);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // end custom code

        // GET: Platforms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platform platform = db.Platforms.Find(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        // GET: Platforms/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Platforms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlatformName,PlatformAddress,PlatformImage")] Platform platform)
        {
            if (ModelState.IsValid)
            {
                db.Platforms.Add(platform);
                db.SaveChanges();
                return RedirectToAction("Index", "Platforms");
            }

            return RedirectToAction("Index", "Platforms");
        }

        // GET: Platforms/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platform platform = db.Platforms.Find(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        // POST: Platforms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlatformName,PlatformAddress,PlatformImage")] Platform platform)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platform).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Platforms");
            }
            return RedirectToAction("Index", "Platforms");
        }

        // GET: Platforms/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platform platform = db.Platforms.Find(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        // POST: Platforms/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Platform platform = db.Platforms.Find(id);
            db.Platforms.Remove(platform);
            db.SaveChanges();
            return RedirectToAction("Index", "Platforms");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
