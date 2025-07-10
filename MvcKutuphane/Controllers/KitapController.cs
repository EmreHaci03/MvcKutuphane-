using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap

        DbKutuphaneEntities5 db = new DbKutuphaneEntities5();
        public ActionResult Index()
        {
            var kitaplar = db.TBL_KİTAP.ToList();
            return View(kitaplar);
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from x in db.TBL_KATEGORİ.ToList()
                                         select new SelectListItem
                                         {
                                             Text=x.Ad,
                                             Value=x.ID.ToString()
                                         }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in db.TBL_YAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.YazarAdSoyad,
                                               Value=x.ID.ToString()    
                                           } 
                                         ).ToList();
            ViewBag.dgr2=deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBL_KİTAP p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //Dikkatli Bak Bu Kısıma!!!!
            var ktg = db.TBL_KATEGORİ.FirstOrDefault(k => k.ID == p.ID);
            var yzr = db.TBL_YAZAR.FirstOrDefault(y => y.ID == p.ID);

            p.TBL_KATEGORİ = ktg;
            p.TBL_YAZAR = yzr;
            
            db.TBL_KİTAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var ktp=db.TBL_KİTAP.Find(id);
            db.TBL_KİTAP.Remove(ktp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TBL_KİTAP.Find(id);
            List<SelectListItem> deger1 = (from x in db.TBL_KATEGORİ.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in db.TBL_YAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.YazarAdSoyad,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir",ktp);
        }
        public ActionResult KitapGuncelle(TBL_KİTAP p)
        {     
            var ktp= db.TBL_KİTAP.Find(p.ID);
            ktp.KitapAd = p.KitapAd;
            ktp.KitapBasimYili = p.KitapBasimYili;
            ktp.KitapYayınEvi = p.KitapYayınEvi;
            ktp.KitapSayfaSayısı = p.KitapSayfaSayısı;
            ktp.KitapDurum = true;
            var ktg = db.TBL_KATEGORİ.Where(x => x.ID == p.TBL_KATEGORİ.ID).FirstOrDefault();
            var yzr = db.TBL_YAZAR.Where(x => x.ID == p.TBL_YAZAR.ID).FirstOrDefault();
            ktp.Kategori = ktg.ID;
            ktp.KitapYazar = yzr.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        
    }
}