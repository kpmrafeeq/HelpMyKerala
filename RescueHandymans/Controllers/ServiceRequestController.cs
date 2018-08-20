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
    public class ServiceRequestController : Controller
    {
        private RescueNeedsEntities db = new RescueNeedsEntities();

        // GET: ServiceRequest
        public ActionResult Index()
        {
            var handyMansRequests = db.HandyMansRequests.Include(h => h.District).Include(h => h.HandyMansService).Include(h => h.Place);
            return View(handyMansRequests.ToList());
        }

        // GET: ServiceRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HandyMansRequest handyMansRequest = db.HandyMansRequests.Find(id);
            if (handyMansRequest == null)
            {
                return HttpNotFound();
            }
            return View(handyMansRequest);
        }

        // GET: ServiceRequest/Create
        public ActionResult Create()
        {
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "Name");
            ViewBag.HandyMansServiceID = new SelectList(db.HandyMansServices, "HandyMansServiceID", "Description");
            ViewBag.PlaceID = db.Places.OrderBy(x => x.Name).ToList();
            return View();
        }

        // POST: ServiceRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HandyMansRequest1,RequesterName,Phone,Email,HandyMansServiceID,DistrictID,PlaceID,CreatedOn,ModifiedOn,Status")] HandyMansRequest handyMansRequest)
        {
            if (ModelState.IsValid)
            {
                handyMansRequest.CreatedOn = DateTime.Now;
                handyMansRequest.ModifiedOn = DateTime.Now;
                handyMansRequest.Status = true;
                db.HandyMansRequests.Add(handyMansRequest);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "Name", handyMansRequest.DistrictID);
            ViewBag.HandyMansServiceID = new SelectList(db.HandyMansServices, "HandyMansServiceID", "Description", handyMansRequest.HandyMansServiceID);
            ViewBag.PlaceID = db.Places.OrderBy(x => x.Name).ToList();
            return View(handyMansRequest);
        }

        // GET: ServiceRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HandyMansRequest handyMansRequest = db.HandyMansRequests.Find(id);
            if (handyMansRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "Name", handyMansRequest.DistrictID);
            ViewBag.HandyMansServiceID = new SelectList(db.HandyMansServices, "HandyMansServiceID", "Description", handyMansRequest.HandyMansServiceID);
            ViewBag.PlaceID = db.Places.OrderBy(x => x.Name).ToList();
            return View(handyMansRequest);
        }

        // POST: ServiceRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HandyMansRequest1,RequesterName,Phone,Email,HandyMansServiceID,DistrictID,PlaceID,CreatedOn,ModifiedOn,Status")] HandyMansRequest handyMansRequest)
        {
            if (ModelState.IsValid)
            {
                handyMansRequest.ModifiedOn = DateTime.Now;
                db.Entry(handyMansRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "Name", handyMansRequest.DistrictID);
            ViewBag.HandyMansServiceID = new SelectList(db.HandyMansServices, "HandyMansServiceID", "Description", handyMansRequest.HandyMansServiceID);
            ViewBag.PlaceID = db.Places.OrderBy(x => x.Name).ToList();
            return View(handyMansRequest);
        }

        // GET: ServiceRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HandyMansRequest handyMansRequest = db.HandyMansRequests.Find(id);
            if (handyMansRequest == null)
            {
                return HttpNotFound();
            }
            return View(handyMansRequest);
        }

        // POST: ServiceRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HandyMansRequest handyMansRequest = db.HandyMansRequests.Find(id);
            db.HandyMansRequests.Remove(handyMansRequest);
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
