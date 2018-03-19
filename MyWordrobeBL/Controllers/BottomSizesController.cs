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
    public class BottomSizesController : Controller
    {
        private WordrobeBLewisEntities db = new WordrobeBLewisEntities();

        // GET: BottomSizes
        public ActionResult Index()
        {
            return View(db.BottomSizes.ToList());
        }

        // GET: BottomSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BottomSize bottomSize = db.BottomSizes.Find(id);
            if (bottomSize == null)
            {
                return HttpNotFound();
            }
            return View(bottomSize);
        }

        // GET: BottomSizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BottomSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BottomSizeID,Size")] BottomSize bottomSize)
        {
            if (ModelState.IsValid)
            {
                db.BottomSizes.Add(bottomSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bottomSize);
        }

        // GET: BottomSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BottomSize bottomSize = db.BottomSizes.Find(id);
            if (bottomSize == null)
            {
                return HttpNotFound();
            }
            return View(bottomSize);
        }

        // POST: BottomSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BottomSizeID,Size")] BottomSize bottomSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bottomSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bottomSize);
        }

        // GET: BottomSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BottomSize bottomSize = db.BottomSizes.Find(id);
            if (bottomSize == null)
            {
                return HttpNotFound();
            }
            return View(bottomSize);
        }

        // POST: BottomSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BottomSize bottomSize = db.BottomSizes.Find(id);
            db.BottomSizes.Remove(bottomSize);
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
