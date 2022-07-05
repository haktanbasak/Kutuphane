using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class KategoriController : BaseController
    {
        // GET: Kategori
        public ActionResult Index()
        {
            var degerler = db.Kategori.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }

        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            db.Kategori.Add(kategori);
            db.SaveChanges();
            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.Kategori.Find(id);
            kategori.Durum = false;
            //db.Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.Kategori.Find(id);
            return View("KategoriGetir",ktg);
        }

        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var ktg = db.Kategori.Find(kategori.Id);
            ktg.Ad = kategori.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}