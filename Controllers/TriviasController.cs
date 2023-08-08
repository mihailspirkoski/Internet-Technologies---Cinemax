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
    [Authorize(Roles = "Admin, StUser")]
    public class TriviasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trivias
        public ActionResult Index()
        {
            return View(db.Trivias.ToList());
        }

        // GET: Trivias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trivia trivia = db.Trivias.Find(id);
            if (trivia == null)
            {
                return HttpNotFound();
            }
            return View(trivia);
        }

        // GET: Trivias/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trivias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TriviaName,TriviaImage,TriviaDescription")] Trivia trivia)
        {
            if (ModelState.IsValid)
            {
                db.Trivias.Add(trivia);
                db.SaveChanges();
                return RedirectToAction("Index", "Trivias");
            }

            return RedirectToAction("Index", "Trivias");
        }

        // GET: Trivias/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trivia trivia = db.Trivias.Find(id);
            if (trivia == null)
            {
                return HttpNotFound();
            }
            return View(trivia);
        }

        // POST: Trivias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TriviaName,TriviaImage,TriviaDescription")] Trivia trivia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trivia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Trivias");
            }
            return RedirectToAction("Index", "Trivias");
        }

        // GET: Trivias/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trivia trivia = db.Trivias.Find(id);
            if (trivia == null)
            {
                return HttpNotFound();
            }
            return View(trivia);
        }

        // POST: Trivias/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trivia trivia = db.Trivias.Find(id);
            db.Trivias.Remove(trivia);
            db.SaveChanges();
            return RedirectToAction("Index", "Trivias");
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
