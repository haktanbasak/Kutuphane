using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class DuyuruController : BaseController
    {
        // GET: Duyuru
        public ActionResult Index()
        {
            var degerler = db.Duyurular.ToList();
            return View(degerler);
        }

        public ActionResult YeniDuyuru()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDuyuru(Duyurular duyuru)
        {
            db.Duyurular.Add(duyuru);
            db.SaveChanges();
            return View();
        }

        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.Duyurular.Find(id);
            db.Duyurular.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruDetay(Duyurular detay)
        {
            var duyuru = db.Duyurular.Find(detay.Id);
            return View("DuyuruDetay",duyuru);
        }

        public ActionResult DuyuruGuncelle(Duyurular duyuru)
        {
            var duyurular = db.Duyurular.Find(duyuru.Id);
            duyurular.Kategori = duyuru.Kategori;
            duyurular.Icerik = duyuru.Icerik;
            duyurular.Tarih = duyuru.Tarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}