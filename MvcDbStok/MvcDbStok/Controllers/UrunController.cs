using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDbStok.Models.Entity;

namespace MvcDbStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult UrunListesi()
        {
            var degerler = db.TblUrunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            // Kategori İsimlerini Getirme Sorgusu
            List<SelectListItem> degerler = (from i in db.TblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(TblUrunler p3)
        {
            // Kategori isimlerinin Id Değerlerini Getiren Sorgu
            var ktg = db.TblKategoriler.Where(m => m.KategoriId == p3.TblKategoriler.KategoriId).FirstOrDefault();
            p3.TblKategoriler = ktg;
            db.TblUrunler.Add(p3);
            db.SaveChanges();
            return RedirectToAction("UrunListesi");
        }

        public ActionResult Sil(int id)
        {
            var urun = db.TblUrunler.Find(id);
            db.TblUrunler.Remove(urun);
            return RedirectToAction("UrunListesi");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TblUrunler.Find(id);
            List<SelectListItem> degerler = (from i in db.TblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(TblUrunler p6)
        {
            var urun = db.TblUrunler.Find(p6.UrunId);
            urun.UrunAd = p6.UrunAd;
            urun.UrunMarka = p6.UrunMarka;
            var ktg = db.TblKategoriler.Where(m => m.KategoriId == p6.TblKategoriler.KategoriId).FirstOrDefault();
            urun.UrunKategori = ktg.KategoriId;

            urun.UrunFiyat = p6.UrunFiyat;
            urun.UrunStok = p6.UrunStok;
            db.SaveChanges();
            return RedirectToAction("UrunListesi");
        }


    }
}