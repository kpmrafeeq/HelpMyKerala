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
    public class HandyMansServicesController : Controller
    {
        private RescueNeedsEntities db = new RescueNeedsEntities();

        // GET: HandyMansServices
        public ActionResult Index()
        {
            return View(db.HandyMansServices.ToList());
        }

        // GET: HandyMansServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HandyMansService handyMansService = db.HandyMansServices.Find(id);
            if (handyMansService == null)
            {
                return HttpNotFound();
            }
            return View(handyMansService);
        }

        // GET: HandyMansServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HandyMansServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HandyMansServiceID,Description")] HandyMansService handyMansService)
        {
            if (ModelState.IsValid)
            {
                db.HandyMansServices.Add(handyMansService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(handyMansService);
        }

        // GET: HandyMansServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HandyMansService handyMansService = db.HandyMansServices.Find(id);
            if (handyMansService == null)
            {
                return HttpNotFound();
            }
            return View(handyMansService);
        }

        // POST: HandyMansServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HandyMansServiceID,Description")] HandyMansService handyMansService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(handyMansService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(handyMansService);
        }

        // GET: HandyMansServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HandyMansService handyMansService = db.HandyMansServices.Find(id);
            if (handyMansService == null)
            {
                return HttpNotFound();
            }
            return View(handyMansService);
        }

        // POST: HandyMansServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HandyMansService handyMansService = db.HandyMansServices.Find(id);
            db.HandyMansServices.Remove(handyMansService);
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
