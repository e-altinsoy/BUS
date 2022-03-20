using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;

namespace Bus.Controllers
{
    [Authorize(Roles = "A")]
    public class CalisanlarController : Controller
    {
        // GET: Calisanlar
        BusBookingEntities db = new BusBookingEntities();
        public ActionResult Index()
        {
            var degerler = db.TblCalisanlars.ToList();
          
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCalisanlarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCalisanlarEkle(TblCalisanlar p2)
        {
            db.TblCalisanlars.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deneme = db.TblCalisanlars.Find(id);
            db.TblCalisanlars.Remove(deneme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CalisanlariGetir(int id)
        {
            var c = db.TblCalisanlars.Find(id);
            return View("CalisanlariGetir", c);
        }
        public ActionResult Guncelle(TblCalisanlar q1)
        {
            var c = db.TblCalisanlars.Find(q1.CalisanlarID);

            c.TblCalisanlarTipler.CalisanTipAd = q1.TblCalisanlarTipler.CalisanTipAd;
            c.TblSubeler.SubeAd = q1.TblSubeler.SubeAd;
            c.Ad = q1.Ad;
            c.Soyad = q1.Soyad;
            c.Email = q1.Email;
            c.Telefon = q1.Telefon;
            c.Adress = q1.Adress;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}