using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class KayitOlController : BaseController
    {
        // GET: KayitOl
        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(Uyeler uye)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.Uyeler.Add(uye);
            db.SaveChanges();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}