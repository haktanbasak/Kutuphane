using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected KutuphaneDBEntities db;
        public BaseController()
        {
            if (db == null)
            {
                db = new KutuphaneDBEntities();
            }
        }
    }
}