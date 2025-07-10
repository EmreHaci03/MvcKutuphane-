using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DbKutuphaneEntities5 db = new DbKutuphaneEntities5();
        public ActionResult Index(int page=1)
        {
            var degerler = db.TBL_UYELER.ToList().ToPagedList(page,5);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBL_UYELER.Find(id);
            db.TBL_UYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBL_UYELER.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeGetir", p); 
            }

            var uye = db.TBL_UYELER.Find(p.ID);
            uye.UyeAdSoyad = p.UyeAdSoyad;
            uye.UyeMail = p.UyeMail;
            uye.UyeKullaniciAd=p.UyeKullaniciAd;
            uye.UyeSifre=p.UyeSifre;
            uye.UyeFotograf=p.UyeFotograf;
            uye.UyeTelefon=p.UyeTelefon;
            uye.UyeOkul=p.UyeOkul;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}