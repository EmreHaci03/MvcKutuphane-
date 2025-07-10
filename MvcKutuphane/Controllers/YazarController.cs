using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DbKutuphaneEntities5 db = new DbKutuphaneEntities5();
        public ActionResult Index()
        {
            var degerler = db.TBL_YAZAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBL_YAZAR p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBL_YAZAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int id)
        {
            var yzr = db.TBL_YAZAR.Find(id);
            db.TBL_YAZAR.Remove(yzr);
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TBL_YAZAR.Find(id);
            return View("YazarGetir",yzr);
        }
        public ActionResult YazarGuncelle(TBL_YAZAR p)
        {
            var yzr = db.TBL_YAZAR.Find(p.ID);
            yzr.ID=p.ID;
            yzr.YazarAdSoyad=p.YazarAdSoyad;
            yzr.YazarDetay=p.YazarDetay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}