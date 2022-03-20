using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;

namespace Bus.Controllers
{
    [Authorize(Roles = "A")]
    public class SeferlerController : Controller
    {
        // GET: Seferler
        BusBookingEntities db = new BusBookingEntities();
        public ActionResult Index()
        {
            var degerler = db.TblSeferlers.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSeferlerekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSeferlerEkle(TblSeferler p11)
        {
            db.TblSeferlers.Add(p11);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deneme = db.TblSeferlers.Find(id);
            db.TblSeferlers.Remove(deneme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SeferlerGetir(int id)
        {
            var s = db.TblSeferlers.Find(id);
            return View("SeferlerGetir", s);
        }
        public ActionResult Guncelle(TblSeferler q1)
        {   
            var s = db.TblSeferlers.Find(q1.SeferID);
            s.TblSehirler.SehirAd = q1.TblSehirler.SehirAd;
            s.TblOtobusler.Plaka = q1.TblOtobusler.Plaka;
            s.TblCalisanlar.Ad = q1.TblCalisanlar.Ad;
            s.KalkisZamani = q1.KalkisZamani;
            s.VarisZamani = q1.VarisZamani;
            s.BiletTutari = q1.BiletTutari;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}