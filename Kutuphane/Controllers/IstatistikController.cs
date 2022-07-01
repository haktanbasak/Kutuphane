using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class IstatistikController : BaseController
    {
        // GET: Istatistik
        public ActionResult Index()
        {
            var deger1 = db.Uyeler.Count();
            var deger2 = db.Kitap.Count();
            var deger3 = db.Kitap.Where(x=>x.Durum==false).Count();
            var deger4 = db.Cezalar.Sum(x=>x.Para);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/web2/resimler"),Path.GetFileName(dosya.FileName));
                dosya.SaveAs(path);
            }
            return RedirectToAction("Galeri");
        }
    }
}