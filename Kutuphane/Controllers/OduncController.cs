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
            var model = db.Hareket.ToList();
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
    }
}