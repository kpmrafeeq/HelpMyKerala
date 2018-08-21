using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RescueHandymans.Data;

namespace RescueHandymans.Controllers
{
    public class ProvidersController : Controller
    {
        private RescueNeedsEntities db = new RescueNeedsEntities();

        // GET: Providers
        public ActionResult Data()
        {
            var handyMans = db.HandyMans.Include(h => h.District).Include(h => h.HandyMansService).Include(h => h.Place);
            return View("Index",handyMans.OrderByDescending(x => x.CreatedOn).ToList());
        }

        // GET: Providers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HandyMan handyMan = db.HandyMans.Find(id);
            if (handyMan == null)
            {
                return HttpNotFound();
            }
            return View(handyMan);
        }

        // GET: Providers/Create
        public ActionResult Create()
        {
            ViewBag.HandyMans = db.HandyMans.Include(h => h.District).Include(h => h.HandyMansService).Include(h => h.Place);
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "Name");
            ViewBag.HandyMansServiceID = new SelectList(db.HandyMansServices, "HandyMansServiceID", "Description");
            return View();
        }

        // POST: Providers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HandyMans,FirstName,LastName,Phone,Email,DistrictID,Area,HandyMansServiceID,CreatedOn,ModifiedOn,Status")] HandyMan handyMan)
        {
            if (ModelState.IsValid)
            {
                handyMan.CreatedOn = DateTime.Now;
                handyMan.ModifiedOn = DateTime.Now;
                handyMan.Status = true;
                db.HandyMans.Add(handyMan);
                db.SaveChanges();
                ViewBag.Satus = "The record updated";
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "Name", handyMan.DistrictID);
            ViewBag.HandyMansServiceID = new SelectList(db.HandyMansServices, "HandyMansServiceID", "Description", handyMan.HandyMansServiceID);
            ViewBag.Satus = "Saved";
            return View(handyMan);
        }

        // GET: Providers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HandyMan handyMan = db.HandyMans.Find(id);
            if (handyMan == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "Name", handyMan.DistrictID);
            ViewBag.HandyMansServiceID = new SelectList(db.HandyMansServices, "HandyMansServiceID", "Description", handyMan.HandyMansServiceID);
            ViewBag.PlaceID = db.Places.OrderBy(x => x.Name).ToList();
            return View(handyMan);
        }

        // POST: Providers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HandyMans,FirstName,LastName,Phone,Email,DistrictID,Area,HandyMansServiceID,CreatedOn,ModifiedOn,Status,Verified")] HandyMan handyMan)
        {
            if (ModelState.IsValid)
            {
                handyMan.ModifiedOn = DateTime.Now;
                db.Entry(handyMan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("data");
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "Name", handyMan.DistrictID);
            ViewBag.HandyMansServiceID = new SelectList(db.HandyMansServices, "HandyMansServiceID", "Description", handyMan.HandyMansServiceID);
            ViewBag.PlaceID = db.Places.OrderBy(x => x.Name).ToList();
            return View(handyMan);
        }

        // GET: Providers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HandyMan handyMan = db.HandyMans.Find(id);
            if (handyMan == null)
            {
                return HttpNotFound();
            }
            return View(handyMan);
        }

        // POST: Providers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HandyMan handyMan = db.HandyMans.Find(id);
            db.HandyMans.Remove(handyMan);
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
