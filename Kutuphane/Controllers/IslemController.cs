using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class IslemController : BaseController
    {
        // GET: Islem
        public ActionResult Index()
        {
            var degerler = db.Hareket.Where(x => x.IslemDurum == true).ToList();
            return View(degerler);
        }
    }
}