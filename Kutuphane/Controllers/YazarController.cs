using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class YazarController : BaseController
    {
        // GET: Yazar

        public ActionResult Index()
        {
            var degerler = db.Yazar.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(Yazar yazar)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.Yazar.Add(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarSil(int id)
        {
            var yzr = db.Yazar.Find(id);
            db.Yazar.Remove(yzr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var yzr = db.Yazar.Find(id);
            return View("YazarGetir",yzr);
        }

        public ActionResult YazarGuncelle(Yazar yazar)
        {
            var yzr = db.Yazar.Find(yazar.Id);
            yzr.Ad = yazar.Ad;
            yzr.Soyad = yazar.Soyad;
            yzr.Detay = yazar.Detay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}