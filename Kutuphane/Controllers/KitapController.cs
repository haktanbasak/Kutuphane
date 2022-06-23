using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class KitapController : BaseController
    {
        // GET: Kitap
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.Kitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.Ad.Contains(p));
            }
            //var kitaplar = db.Kitap.ToList();
            return View(kitaplar.ToList());
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.Kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.Yazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + " " + i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(Kitap kitap)
        {
            var ktg = db.Kategori.Where(x => x.Id == kitap.Kategori1.Id).FirstOrDefault();
            var yzr = db.Yazar.Where(x => x.Id == kitap.Yazar1.Id).FirstOrDefault();
            kitap.Kategori1 = ktg;
            kitap.Yazar1 = yzr;
            db.Kitap.Add(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var ktp = db.Kitap.Find(id);
            db.Kitap.Remove(ktp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var ktp = db.Kitap.Find(id);
            List<SelectListItem> deger1 = (from i in db.Kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.Yazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + " " + i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktp);
        }

        public ActionResult KitapGuncelle(Kitap kitap)
        {
            var ktp = db.Kitap.Find(kitap.Id);
            ktp.Ad = kitap.Ad;
            ktp.BasimYil = kitap.BasimYil;
            ktp.Sayfa = kitap.Sayfa;
            ktp.Yayinevi = kitap.Yayinevi;
            var ktg = db.Kategori.Where(x => x.Id == kitap.Kategori1.Id).FirstOrDefault();
            var yzr = db.Yazar.Where(x => x.Id == kitap.Yazar1.Id).FirstOrDefault();
            ktp.Kategori = ktg.Id;
            ktp.Yazar = yzr.Id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}