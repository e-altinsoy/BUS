using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;

namespace Bus.Controllers
{
    [Authorize(Roles = "A")]
    public class SepetController : Controller
    {
        // GET: Sepet
        BusBookingEntities db = new BusBookingEntities();
        public ActionResult Index(decimal? Tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = db.TblKullanicilars.FirstOrDefault(x => x.KullaniciAd == kullaniciadi);
                var model = db.TblSepets.Where(x => x.KullaniciID == kullanici.KullaniciID).ToList();
                var kid = db.TblSepets.FirstOrDefault(x => x.KullaniciID == kullanici.KullaniciID);
                if (model != null)
                {
                    if (kid == null)
                    {
                        ViewBag.Tutar = "Sepetinizde Urun Bulunmuyor";
                    }
                    //else if (kid != null)
                    //{
                    //    Tutar = db.TblSepets.Where(x => x.KullaniciID == kid.KullaniciID).Sum(x => x.ToplamFiyat);
                    //    ViewBag.Tutar = "Toplam Tutar = " + Tutar + "TL";
                    //}
                    return View(model);
                }

            }
            return HttpNotFound();
        }

        public ActionResult SepeteEkle(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var model = db.TblKullanicilars.FirstOrDefault(x => x.KullaniciAd == kullaniciadi);
                var b = db.TblBiletlers.Find(id);

                var sepet = db.TblSepets.FirstOrDefault(x => x.KullaniciID == model.KullaniciID && x.BiletID == id);
                if (sepet != null)
                {
                    sepet.Fiyat++;
                    sepet.ToplamFiyat = b.Ucret + sepet.Fiyat;
                    db.SaveChanges();
                    RedirectToAction("Index");

                }
                var s = new TblSepet
                {
                    KullaniciID = model.KullaniciID,
                    MusteriID = b.MusteriID,
                    BiletID = b.BIletID,
                    OtobusID = b.TblSeferler.OtobusID,
                    SeferID = b.SeferID,
                    SehirID = b.TblSeferler.TblSehirler.SehirID,
                    Fiyat = b.Ucret,
                    //ToplamFiyat = b.Ucret + sepet.Fiyat,
                    Tarih = DateTime.Now
                    //Saat = DateTime.Now
             };
                db.Entry(s).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return HttpNotFound();
        }

       
        public ActionResult Sil(int id)
        {
            var deneme = db.TblSepets.Find(id);
            db.TblSepets.Remove(deneme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SepetGetir(int id)
        {
            var spt = db.TblSepets.Find(id);
            return View("SepetGetir", spt);
        }
        public ActionResult Guncelle(TblSepet q1)
        {
            var spt = db.TblSepets.Find(q1.SepetID);
            spt.TblMusteriler.TC = q1.TblMusteriler.TC;
            spt.TblMusteriler.Ad = q1.TblMusteriler.Ad;
            spt.TblMusteriler.Soyad = q1.TblMusteriler.Soyad;

            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }

}  
