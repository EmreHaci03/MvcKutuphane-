using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbKutuphaneEntities5 db = new DbKutuphaneEntities5();
        public ActionResult Index()
        {
            var degerler = db.TBL_KATEGORİ.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(TBL_KATEGORİ p)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");  
            }

            db.TBL_KATEGORİ.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori=db.TBL_KATEGORİ.Find(id);
            db.TBL_KATEGORİ.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBL_KATEGORİ.Find(id);
            return View("KategoriGetir", ktg);
        }

        public ActionResult KategoriGüncelle(TBL_KATEGORİ p)
        {
            var gdeger = db.TBL_KATEGORİ.Find(p.ID);
            gdeger.Ad = p.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}