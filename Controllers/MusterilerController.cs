using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;
namespace Bus.Controllers
{
    [Authorize(Roles = "A")]
    public class MusterilerController : Controller
    {
        // GET: Musreriler
        BusBookingEntities db = new BusBookingEntities();
        public ActionResult Index()
        {
            var degerler = db.TblMusterilers.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusterilerEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusterilerEkle(TblMusteriler p8)
        {
            db.TblMusterilers.Add(p8);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deneme = db.TblMusterilers.Find(id);
            db.TblMusterilers.Remove(deneme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusterilerGetir(int id)
        {
            var ms = db.TblMusterilers.Find(id);
            return View("MusterilerGetir", ms);
        }
        public ActionResult Guncelle(TblMusteriler q1)
        {
            var ms = db.TblMusterilers.Find(q1.MusteriID);

            ms.TC = q1.TC;
            ms.Ad = q1.Ad;
            ms.Soyad = q1.Soyad;
            ms.Email = q1.Email;
            ms.Telefon = q1.Telefon;
            ms.Cinsiyet = q1.Cinsiyet;
            ms.DogumTarihi = q1.DogumTarihi;
            ms.Adress = q1.Adress;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
       
    }
}