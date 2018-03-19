using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWordrobeBL.Models;

namespace MyWordrobeBL.Controllers
{
    public class BottomsController : Controller
    {
        private WordrobeBLewisEntities db = new WordrobeBLewisEntities();

        // GET: Bottoms
        public ActionResult Index()
        {
            var bottoms = db.Bottoms.Include(b => b.BottomSize).Include(b => b.Color).Include(b => b.Occasion).Include(b => b.Photo).Include(b => b.Season);
            return View(bottoms.ToList());
        }

        // GET: Bottoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottom bottom = db.Bottoms.Find(id);
            if (bottom == null)
            {
                return HttpNotFound();
            }
            return View(bottom);
        }

        // GET: Bottoms/Create
        public ActionResult Create()
        {
            ViewBag.BottomSizeID = new SelectList(db.BottomSizes, "BottomSizeID", "Size");
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorChoice");
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Occasion1");
            ViewBag.PhotoID = new SelectList(db.Photos, "PhotoID", "Photo1");
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Season1");
            return View();
        }

        // POST: Bottoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BottomsID,Name,BottomSizeID,PhotoID,SeasonID,OccasionID,ColorID")] Bottom bottom)
        {
            if (ModelState.IsValid)
            {
                db.Bottoms.Add(bottom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BottomSizeID = new SelectList(db.BottomSizes, "BottomSizeID", "Size", bottom.BottomSizeID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorChoice", bottom.ColorID);
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Occasion1", bottom.OccasionID);
            ViewBag.PhotoID = new SelectList(db.Photos, "PhotoID", "Photo1", bottom.PhotoID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Season1", bottom.SeasonID);
            return View(bottom);
        }

        // GET: Bottoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottom bottom = db.Bottoms.Find(id);
            if (bottom == null)
            {
                return HttpNotFound();
            }
            ViewBag.BottomSizeID = new SelectList(db.BottomSizes, "BottomSizeID", "Size", bottom.BottomSizeID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorChoice", bottom.ColorID);
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Occasion1", bottom.OccasionID);
            ViewBag.PhotoID = new SelectList(db.Photos, "PhotoID", "Photo1", bottom.PhotoID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Season1", bottom.SeasonID);
            return View(bottom);
        }

        // POST: Bottoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BottomsID,Name,BottomSizeID,PhotoID,SeasonID,OccasionID,ColorID")] Bottom bottom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bottom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BottomSizeID = new SelectList(db.BottomSizes, "BottomSizeID", "Size", bottom.BottomSizeID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorChoice", bottom.ColorID);
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Occasion1", bottom.OccasionID);
            ViewBag.PhotoID = new SelectList(db.Photos, "PhotoID", "Photo1", bottom.PhotoID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Season1", bottom.SeasonID);
            return View(bottom);
        }

        // GET: Bottoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottom bottom = db.Bottoms.Find(id);
            if (bottom == null)
            {
                return HttpNotFound();
            }
            return View(bottom);
        }

        // POST: Bottoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bottom bottom = db.Bottoms.Find(id);
            db.Bottoms.Remove(bottom);
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
