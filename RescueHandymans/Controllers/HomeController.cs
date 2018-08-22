using RescueHandymans.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RescueHandymans.Controllers
{
    public class HomeController : Controller
    {
        private RescueNeedsEntities db = new RescueNeedsEntities();

        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult SearchServices()
        {
            ViewBag.SelectedDistrict = 0;
            ViewBag.SelectedServices = 0;
            ViewBag.Search = false;
            ViewBag.Districts = db.Districts.ToList();
            ViewBag.Services = db.HandyMansServices.ToList();
            return View(new List<HandyMan>());
        }

        [HttpPost]
        public ActionResult SearchServices(string district, string service)
        {
            var handymans = db.HandyMans.AsEnumerable();
            ViewBag.Districts = db.Districts.ToList();
            ViewBag.Services = db.HandyMansServices.ToList();
            ViewBag.SelectedDistrict = 0;
            ViewBag.SelectedServices = 0;
            int districtId;
            int serviceId;
            ViewBag.Search = true;
            if (int.TryParse(district, out districtId))
            {
                ViewBag.SelectedDistrict = districtId;
                handymans = handymans.Where(x => x.DistrictID == districtId);
            }
            if (int.TryParse(service, out serviceId))
            {
                ViewBag.SelectedServices = serviceId;
                handymans = handymans.Where(x => x.HandyMansServiceID == serviceId);
            }

            return View(handymans.OrderByDescending(x=>x.Verified  == true).ThenByDescending(x=>x.CreatedOn).ToList());
        }

        [HttpGet]
        public ActionResult Disclaimer()
        {
            return View();
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