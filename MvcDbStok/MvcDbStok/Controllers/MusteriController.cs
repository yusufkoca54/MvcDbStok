using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDbStok.Models.Entity;

namespace MvcDbStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult MusteriListesi(string p8)
        {
            var degerler = from d in db.TblMusteriler select d;
            if (!string.IsNullOrEmpty(p8))
            {
                degerler = degerler.Where(m => m.MusteriAd.Contains(p8));
            }
            return View(degerler.ToList());
        }

        [HttpGet]
        public ActionResult MusteriEkle()
        {
           
            return View();
        }


        [HttpPost]
        public ActionResult MusteriEkle(TblMusteriler p2)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriEkle");
            }
            db.TblMusteriler.Add(p2);
            db.SaveChanges();
            return RedirectToAction("MusteriListesi");
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.TblMusteriler.Find(id);
            db.TblMusteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("MusteriListesi");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TblMusteriler.Find(id);
            return View("MusteriGetir",mus);
        }

        public ActionResult Guncelle(TblMusteriler p5)
        {
            var musteri = db.TblMusteriler.Find(p5.MusteriId);
            musteri.MusteriAd = p5.MusteriAd;
            musteri.MusteriSoyad = p5.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("MusteriListesi");
        }

    }
}