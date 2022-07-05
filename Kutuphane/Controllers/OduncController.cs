using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class OduncController : BaseController
    {
        // GET: Odunc
        public ActionResult Index()
        {
            var model = db.Hareket.Where(x=>x.IslemDurum == false).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.Uyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad + " " + x.Soyad,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from y in db.Kitap.Where(x=>x.Durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.Ad,
                                               Value = y.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from x in db.Personel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Personel1,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(Hareket hareket)
        {
            var d1 = db.Uyeler.Where(x => x.Id == hareket.Uyeler.Id).FirstOrDefault();
            var d2 = db.Kitap.Where(x => x.Id == hareket.Kitap1.Id).FirstOrDefault();
            var d3 = db.Personel.Where(x => x.Id == hareket.Personel1.Id).FirstOrDefault();
            hareket.Uyeler = d1;
            hareket.Kitap1 = d2;
            hareket.Personel1 = d3;
            db.Hareket.Add(hareket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OduncIade(Hareket hareket)
        {
            var odn = db.Hareket.Find(hareket.Id);
            DateTime d1 = DateTime.Parse(odn.IadeTarih.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr1 = d3;
            return View("OduncIade", odn);
        }

        public ActionResult OduncGuncelle(Hareket hareket)
        {
            var hrk = db.Hareket.Find(hareket.Id);
            hrk.UyeGetirTarih = hareket.UyeGetirTarih;
            hrk.IslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}