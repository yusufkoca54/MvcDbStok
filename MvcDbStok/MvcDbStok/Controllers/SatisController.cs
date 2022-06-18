using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDbStok.Models.Entity;

namespace MvcDbStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult SatisListesi()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]

        public ActionResult YeniSatis(TblSatislar p7)
        {
            db.TblSatislar.Add(p7);
            db.SaveChanges();
            return View("SatisListesi");
        }
    }
}