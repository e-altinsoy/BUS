using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Models.Entity;
namespace Bus.Controllers
{
    public class KoltukController : Controller
    {
        // GET: Koltuk
        BusBookingEntities db = new BusBookingEntities();
        public ActionResult Index()
        {
            var degerler = db.TblKoltuklars.ToList();
            return View(degerler);
        }
    }
}