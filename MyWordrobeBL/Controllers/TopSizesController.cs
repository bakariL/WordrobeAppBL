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
    public class TopSizesController : Controller
    {
        private WordrobeBLewisEntities db = new WordrobeBLewisEntities();

        // GET: TopSizes
        public ActionResult Index()
        {
            return View(db.TopSizes.ToList());
        }

        // GET: TopSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopSize topSize = db.TopSizes.Find(id);
            if (topSize == null)
            {
                return HttpNotFound();
            }
            return View(topSize);
        }

        // GET: TopSizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TopSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TopSizeID,Size")] TopSize topSize)
        {
            if (ModelState.IsValid)
            {
                db.TopSizes.Add(topSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topSize);
        }

        // GET: TopSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopSize topSize = db.TopSizes.Find(id);
            if (topSize == null)
            {
                return HttpNotFound();
            }
            return View(topSize);
        }

        // POST: TopSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TopSizeID,Size")] TopSize topSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topSize);
        }

        // GET: TopSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopSize topSize = db.TopSizes.Find(id);
            if (topSize == null)
            {
                return HttpNotFound();
            }
            return View(topSize);
        }

        // POST: TopSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TopSize topSize = db.TopSizes.Find(id);
            db.TopSizes.Remove(topSize);
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
