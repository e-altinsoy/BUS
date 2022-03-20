using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;
namespace Bus.Controllers
{
    [Authorize(Roles = "A")]
    public class OtobusMasraflariController : Controller
    {
        // GET: OtobusMasraflari
        BusBookingEntities db = new BusBookingEntities();
        public ActionResult Index()
        {
            var degerler = db.TblOtobusMasraflaris.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniOtobusMasrafEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniOtobusMasrafEkle(TblOtobusMasraflari p10)
        {
            db.TblOtobusMasraflaris.Add(p10);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deneme = db.TblOtobusMasraflaris.Find(id);
            db.TblOtobusMasraflaris.Remove(deneme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OtobusMasraflariGetir(int id)
        {
            var om = db.TblOtobusMasraflaris.Find(id);
            return View("OtobusMasraflariGetir", om);
        }
        public ActionResult Guncelle(TblOtobusMasraflari q1)
        {
            var om = db.TblOtobusMasraflaris.Find(q1.OtobusMasrafID);

            om.TblOtobusler.Plaka = q1.TblOtobusler.Plaka;
            om.TblMasrafTipleri.MasrafAd = q1.TblMasrafTipleri.MasrafAd;
            om.Tutar = q1.Tutar;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}