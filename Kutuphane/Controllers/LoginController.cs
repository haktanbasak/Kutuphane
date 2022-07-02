using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Kutuphane.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Uyeler uye)
        {
            var bilgiler = db.Uyeler.FirstOrDefault(x => x.Mail == uye.Mail && x.Sifre == uye.Sifre);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
                Session["Mail"] = bilgiler.Mail.ToString();
                //TempData["id"] = bilgiler.Id.ToString();
                //TempData["Ad"] = bilgiler.Ad.ToString();
                //TempData["Soyad"] = bilgiler.Soyad.ToString();
                //TempData["KullanıcıAdı"] = bilgiler.KullaniciAdi.ToString();
                //TempData["Sifre"] = bilgiler.Sifre.ToString();
                //TempData["Uni"] = bilgiler.Okul.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}