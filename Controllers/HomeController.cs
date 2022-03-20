using Bus.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bus.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        BusBookingEntities db = new BusBookingEntities();
       [HttpGet]
        public ActionResult Index()
        {
            List<SelectListItem> degerler = (from i in db.TblSehirlers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.SehirAd,
                                                 Value = i.SehirID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
         
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Search(TblSeferler b)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (b!=null)
                    {
                        var sefer = db.TblSeferlers.Where(x => x.KalkisSehirID==b.KalkisSehirID && x.VarisSehirID==b.VarisSehirID &&x.KalkisZamani.Day==b.KalkisZamani.Day&&x.KalkisZamani.Year==b.KalkisZamani.Year&&x.KalkisZamani.Month==b.KalkisZamani.Month).ToList();
                        return View(sefer);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Bilgi()
        {
           

            return View();
        }
    }

}