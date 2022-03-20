using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;

namespace Bus.Controllers
{
    [Authorize(Roles = "A")]
    public class MarkalarController : Controller
    {
        // GET: Markalar
        BusBookingEntities db = new BusBookingEntities();
        public ActionResult Index()
        {
            var degerler = db.TblMarkalars.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMarkalarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMarkalarEkle(TblMarkalar p5)
        {
            db.TblMarkalars.Add(p5);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deneme = db.TblMarkalars.Find(id);
            db.TblMarkalars.Remove(deneme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MarkalarGetir(int id)
        {
            var mrk = db.TblMarkalars.Find(id);
            return View("MarkalarGetir", mrk);
        }
        public ActionResult Guncelle(TblMarkalar q1)
        {
            var mrk = db.TblMarkalars.Find(q1.MarkaID);
            mrk.MarkaAd = q1.MarkaAd;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}