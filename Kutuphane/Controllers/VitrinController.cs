using Kutuphane.Models.Entity;
using Kutuphane.Models.Sınıflarım;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class VitrinController : BaseController
    {
        // GET: Vitrin
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.Kitap.ToList();
            cs.Deger2 = db.Hakkimizda.ToList();
            //var degerler = db.Kitap.ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult Index(Iletisim iletisim)
        {
            db.Iletisim.Add(iletisim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}