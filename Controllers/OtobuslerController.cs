using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;

namespace Bus.Controllers
{
    [Authorize(Roles = "A")]
    public class OtobuslerController : Controller
    {
        // GET: Otobusler
        BusBookingEntities db = new BusBookingEntities();
        public ActionResult Index()
        {
            var degerler = db.TblOtobuslers.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniOtobuslerEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniOtobuslerEkle(TblOtobusler p9)
        {
            db.TblOtobuslers.Add(p9);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deneme = db.TblOtobuslers.Find(id);
            db.TblOtobuslers.Remove(deneme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OtobusleriGetir(int id)
        {
            var o = db.TblOtobuslers.Find(id);
            return View("OtobusleriGetir", o);
        }
        public ActionResult Guncelle(TblOtobusler q1)
        {
            var o = db.TblOtobuslers.Find(q1.OtobusID);

            o.Plaka = q1.Plaka;
            o.KoltukSayisi = q1.KoltukSayisi;
            o.TblMarkalar.MarkaAd = q1.TblMarkalar.MarkaAd;
            o.AktifMi = q1.AktifMi;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}