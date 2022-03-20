using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;

namespace Bus.Controllers
{
    [Authorize(Roles = "A")]
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        BusBookingEntities db = new BusBookingEntities();
        public ActionResult Index()
        {
            var degerler = db.TblMesajlars.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesajlarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesajlarEkle(TblMesajlar p7)
        {
            db.TblMesajlars.Add(p7);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deneme = db.TblMesajlars.Find(id);
            db.TblMesajlars.Remove(deneme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MesajlariGetir(int id)
        {
            var msj = db.TblMesajlars.Find(id);
            return View("MesajlariGetir", msj);
        }
        public ActionResult Guncelle(TblMesajlar q1)
        {
            var msj = db.TblMesajlars.Find(q1.MesajID);

            msj.Ad= q1.Ad;
            msj.Soyad = q1.Soyad;
            msj.Email = q1.Email;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}