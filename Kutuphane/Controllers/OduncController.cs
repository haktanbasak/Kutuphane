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
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(Hareket hareket)
        {
            db.Hareket.Add(hareket);
            db.SaveChanges();
            return View();
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