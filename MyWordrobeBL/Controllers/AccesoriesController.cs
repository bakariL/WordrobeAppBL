using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWordrobeBL.Models;

namespace MyWordrobeBL.ControllersB
{
    public class AccesoriesController : Controller
    {
        private WordrobeBLewisEntities db = new WordrobeBLewisEntities();

        // GET: Accesories
        public ActionResult Index()
        {
            var accesories = db.Accesories.Include(a => a.Occasion).Include(a => a.Photo);
            return View(accesories.ToList());
        }

        // GET: Accesories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accesory accesory = db.Accesories.Find(id);
            if (accesory == null)
            {
                return HttpNotFound();
            }
            return View(accesory);
        }

        // GET: Accesories/Create
        public ActionResult Create()
        {
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Occasion1");
            ViewBag.PhotoID = new SelectList(db.Photos, "PhotoID", "Photo1");
            return View();
        }

        // POST: Accesories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccesoriesID,Name,PhotoID,OccasionID")] Accesory accesory)
        {
            if (ModelState.IsValid)
            {
                db.Accesories.Add(accesory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Occasion1", accesory.OccasionID);
            ViewBag.PhotoID = new SelectList(db.Photos, "PhotoID", "Photo1", accesory.PhotoID);
            return View(accesory);
        }

        // GET: Accesories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accesory accesory = db.Accesories.Find(id);
            if (accesory == null)
            {
                return HttpNotFound();
            }
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Occasion1", accesory.OccasionID);
            ViewBag.PhotoID = new SelectList(db.Photos, "PhotoID", "Photo1", accesory.PhotoID);
            return View(accesory);
        }

        // POST: Accesories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccesoriesID,Name,PhotoID,OccasionID")] Accesory accesory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accesory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Occasion1", accesory.OccasionID);
            ViewBag.PhotoID = new SelectList(db.Photos, "PhotoID", "Photo1", accesory.PhotoID);
            return View(accesory);
        }

        // GET: Accesories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accesory accesory = db.Accesories.Find(id);
            if (accesory == null)
            {
                return HttpNotFound();
            }
            return View(accesory);
        }

        // POST: Accesories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accesory accesory = db.Accesories.Find(id);
            db.Accesories.Remove(accesory);
            db.SaveChanges();
            return RedirectToAction("Index");
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
