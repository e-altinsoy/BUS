using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;

namespace Bus.Controllers
{
    [Authorize(Roles = "A,U")]
    public class SubelerController : Controller
    {
        // GET: Subeler
        BusBookingEntities db = new BusBookingEntities();      
        public ActionResult Index()
        {
            var degerler = db.TblSubelers.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSubelerekle()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult YeniSubelerEkle(TblSubeler p13)
        {
            
            db.TblSubelers.Add(p13);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deneme = db.TblSubelers.Find(id);
            db.TblSubelers.Remove(deneme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SubelerGetir(int id)
        {
            var sb = db.TblSubelers.Find(id);
            return View("SubelerGetir", sb);
        }
        public ActionResult Guncelle(TblSubeler q1)
        {
            var sb = db.TblSubelers.Find(q1.SubeID);
            sb.SubeAd = q1.SubeAd;
            sb.TblSehirler.SehirAd = q1.TblSehirler.SehirAd;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}