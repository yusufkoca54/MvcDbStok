using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDbStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcDbStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult KategoriListesi(int sayfa=1)
        {
            // var degerler = db.TblKategoriler.ToList();
            var degerler = db.TblKategoriler.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult KategoriEkle(TblKategoriler p1)
        {
            if(!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            db.TblKategoriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("KategoriListesi");
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.TblKategoriler.Find(id);
            db.TblKategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("KategoriListesi");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TblKategoriler.Find(id);
            return View("KategoriGetir",ktgr);
        } 

        public ActionResult Guncelle(TblKategoriler p4)
        {
            var ktg = db.TblKategoriler.Find(p4.KategoriId);
            ktg.KategoriAd = p4.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("KategoriListesi");
        }
    }
}