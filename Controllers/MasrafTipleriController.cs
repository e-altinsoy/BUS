using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;

namespace Bus.Controllers
{
    [Authorize(Roles = "A")]
    public class MasrafTipleriController : Controller
    {
        // GET: MasrafTipleri
        BusBookingEntities db = new BusBookingEntities();
        public ActionResult Index()
        {
            var deger = db.TblMasrafTipleris.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniMasrafTipleriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMasrafTipleriEkle(TblMasrafTipleri p6)
        {
            db.TblMasrafTipleris.Add(p6);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deneme = db.TblMasrafTipleris.Find(id);
            db.TblMasrafTipleris.Remove(deneme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MasrafTipleriGetir(int id)
        {
            var mtip = db.TblMasrafTipleris.Find(id);
            return View("MasrafTipleriGetir", mtip);
        }
        public ActionResult Guncelle(TblMasrafTipleri q1)
        {
            var mtip = db.TblMasrafTipleris.Find(q1.MasrafTipID);
            mtip.MasrafAd = q1.MasrafAd;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}