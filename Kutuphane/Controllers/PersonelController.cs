using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class PersonelController : BaseController
    {
        // GET: Personel
        public ActionResult Index()
        {
            var personeller = db.Personel.ToList();
            return View(personeller);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.Personel.Add(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var personel = db.Personel.Find(id);
            db.Personel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var prs = db.Personel.Find(id);
            return View("PersonelGetir", prs);
        }

        public ActionResult PersonelGuncelle(Personel personel)
        {
            var prs = db.Personel.Find(personel.Id);
            prs.Personel1 = personel.Personel1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}