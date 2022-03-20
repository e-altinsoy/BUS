using Bus.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Bus.Controllers
{
    [AllowAnonymous]
    public class KullanicilarController : Controller
    {

        // GET: Security
        BusBookingEntities db = new BusBookingEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(TblKullanicilar k)
        {
            var kullanici = db.TblKullanicilars.FirstOrDefault(x => x.KullaniciAd == k.KullaniciAd && x.Sifre == k.Sifre);

            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(k.KullaniciAd, false);
                return RedirectToAction("Index", "Sehirler");
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı Adı veya Şifre Yanlış";
                return View();
            }
             
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(TblKullanicilar k)
        {
          
            var model = db.TblKullanicilars.Where(x => x.Email == k.Email).FirstOrDefault();
            if (model != null)
            {
                Guid rastgele = Guid.NewGuid();
                model.Sifre = rastgele.ToString().Substring(0, 8);
                db.SaveChanges();
                SmtpClient client = new SmtpClient("smtp.yandex.ru", 587);
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("fitboyxx7@hotmail.co.uk", "Sifre Sifirlama");
                mail.To.Add(model.Email);
                mail.IsBodyHtml = true;
                mail.Subject = "Sifre degistirme Istegi";
                mail.Body += "merhaba" + model.AdSoyad + "<br/> Kullanici Adiniz = " + model.KullaniciAd + "<br/> Sifreniz =" + model.Sifre;
                NetworkCredential net = new NetworkCredential("fitboyxx7@hotmail.co.uk", "England68");
                client.Credentials = net;
                client.Send(mail);
                return RedirectToAction("Login");
            }
            ViewBag.hata = "Boyle bir e-mail adresi bulunamadi!!";
            return View();

        }

        [HttpGet]
        public ActionResult Kaydol()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kaydol(TblKullanicilar k)
        {
            if ( ! ModelState.IsValid) return View();
            k.Rol = "U";
            db.Entry(k).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Login");
        }

    }
}