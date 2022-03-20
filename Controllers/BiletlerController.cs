using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;
namespace Bus.Controllers
{
    [Authorize(Roles ="A")]
    public class BiletlerController : Controller
    {
        // GET: Biletler
        BusBookingEntities db = new BusBookingEntities();
        public ActionResult Index()
        {
            var degerler = db.TblBiletlers.ToList();
            return View(degerler);
        }[HttpGet]
        public ActionResult YeniBiletlerEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBiletlerekle(TblBiletler p1)
        {
            db.TblBiletlers.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deneme = db.TblBiletlers.Find(id);
            db.TblBiletlers.Remove(deneme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Yolcu()
        {
            //List<SelectListItem> degerler = (from i in db.TblBiletler.ToList()
            //                                 select new SelectListItem
            //                                 {
            //                                     Text = i.Cinsiyet,
            //                                     Value = i.MusteriID.ToString()
            //                                 }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Yolcu(TblBiletler y)
        {
            db.TblBiletlers.Add(y);
            db.SaveChanges();
            return View();
        }
    }
}