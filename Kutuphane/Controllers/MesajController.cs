using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class MesajController : BaseController
    {
        // GET: Mesaj
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.Mesajlar.Where(x=>x.Alici == uyemail.ToString()).ToList();
            return View(mesajlar);
        }

        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.Mesajlar.Where(x => x.Gonderen == uyemail.ToString()).ToList();
            return View(mesajlar);
        }

        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar mesaj)
        {
            var uyemail = (string)Session["Mail"].ToString();
            mesaj.Gonderen = uyemail.ToString();
            mesaj.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Mesajlar.Add(mesaj);
            db.SaveChanges();
            return RedirectToAction("Giden","Mesaj");
        }
    }
}