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

        public ActionResult LinqKart()
        {
            var deger1 = db.Kitap.Count();
            var deger2 = db.Uyeler.Count();
            var deger3 = db.Cezalar.Sum(x => x.Para);
            var deger4 = db.Kitap.Where(x => x.Durum == false).Count();
            var deger5 = db.Kategori.Count();
            var deger6 = db.Hareket.GroupBy(x=>(x.Uyeler.Ad + " " + x.Uyeler.Soyad)).OrderByDescending(x=>x.Count()).Select(x=> new {x.Key }).FirstOrDefault();
            var deger7 = db.Hareket.GroupBy(x => x.Kitap1.Ad).OrderByDescending(x => x.Count()).Select(x => new { x.Key }).FirstOrDefault();
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault(); //Sql prosedür yazıp oradan çağırdık
            var deger9 = db.Kitap.GroupBy(x => x.Yayinevi).OrderByDescending(x => x.Count()).Select(x => new { x.Key }).FirstOrDefault();
            var deger10 = db.Hareket.GroupBy(x => x.Personel1.Personel1).OrderByDescending(x => x.Count()).Select(x => new { x.Key }).FirstOrDefault();
            var deger11 = db.Iletisim.Count();
            var deger12 = db.Hareket.Where(x=>x.AlisTarih==DateTime.Today).Select(c=>c.Kitap).Count();
            ViewBag.dgr1 = deger1; 
            ViewBag.dgr2 = deger2; 
            ViewBag.dgr3 = deger3; 
            ViewBag.dgr4 = deger4; 
            ViewBag.dgr5 = deger5; 
            ViewBag.dgr6 = deger6; 
            ViewBag.dgr7 = deger7; 
            ViewBag.dgr8 = deger8; 
            ViewBag.dgr9 = deger9; 
            ViewBag.dgr10 = deger10; 
            ViewBag.dgr11 = deger11; 
            ViewBag.dgr12 = deger12; 
            return View();
        }
    }
}