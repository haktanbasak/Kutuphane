using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    [Authorize]
    public class PanelimController : BaseController
    {
        // GET: Panelim
        public ActionResult Index()
        {
            var uyeMail = (string)Session["Mail"];
            var degerler = db.Uyeler.FirstOrDefault(x => x.Mail == uyeMail);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index2(Uyeler uyeler)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.Uyeler.FirstOrDefault(x=>x.Mail == kullanici);
            uye.Sifre = uyeler.Sifre;
            uye.Ad = uyeler.Ad;
            uye.Fotograf = uyeler.Fotograf;
            uye.Okul = uyeler.Okul;
            uye.KullaniciAdi = uyeler.KullaniciAdi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}