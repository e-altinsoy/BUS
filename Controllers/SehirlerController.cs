using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;

namespace Bus.Controllers
{
    //[Authorize(Roles = "A,U")]
    public class SehirlerController : Controller
    {
        // GET: Sehirler
        BusBookingEntities db = new BusBookingEntities();
        public ActionResult Index()
        {
            var degerler = db.TblSehirlers.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSehirlerEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSehirlerEkle(TblSehirler Sehirler)
        {
         
            db.TblSehirlers.Add(Sehirler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       public ActionResult Sil (int id)
        {
            var deneme = db.TblSehirlers.Find(id);
            db.TblSehirlers.Remove(deneme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SehirGetir(int id)
        {
            var shr = db.TblSehirlers.Find(id);
            return View("SehirGetir", shr);
        }
        public ActionResult Guncelle(TblSehirler q1)
        {
            var shr = db.TblSehirlers.Find(q1.SehirID);
            shr.SehirAd = q1.SehirAd;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}