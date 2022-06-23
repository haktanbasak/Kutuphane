using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Kutuphane.Controllers
{
    public class UyeController : BaseController
    {
        // GET: Uye
        public ActionResult Index(int sayfa = 1)
        {
            var uyeler = db.Uyeler.ToList().ToPagedList(sayfa,3);
            return View(uyeler);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(Uyeler uye)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.Uyeler.Add(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeSil(int id)
        {
            var uye = db.Uyeler.Find(id);
            db.Uyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.Uyeler.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(Uyeler uye)
        {
            var uyeler = db.Uyeler.Find(uye.Id);
            uyeler.Ad = uye.Ad;
            uyeler.Soyad = uye.Soyad;
            uyeler.Mail = uye.Mail;
            uyeler.KullaniciAdi = uye.KullaniciAdi;
            uyeler.Sifre = uye.Sifre;
            uyeler.Telefon = uye.Telefon;
            uyeler.Okul = uye.Okul;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}