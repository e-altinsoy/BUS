using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;

namespace Bus.Controllers
{
    [Authorize(Roles = "A")]
    public class CalisanlarTipController : Controller
    {
        // GET: CalisanlarTip
        BusBookingEntities db = new BusBookingEntities();
        public ActionResult Index()
        {
            var degerler = db.TblCalisanlarTiplers.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCalisanlarTipEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCalisanlarTipEkle(TblCalisanlarTipler p3)
        {
            db.TblCalisanlarTiplers.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deneme = db.TblCalisanlarTiplers.Find(id);
            db.TblCalisanlarTiplers.Remove(deneme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CalisanTipGetir(int id)
        {
            var shr = db.TblCalisanlarTiplers.Find(id);
            return View("CalisanTipGetir", shr);
        }
        public ActionResult Guncelle(TblCalisanlarTipler q1)
        {
            var ctip = db.TblCalisanlarTiplers.Find(q1.CalisanTipID);
            ctip.CalisanTipAd = q1.CalisanTipAd;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}