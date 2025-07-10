using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DbKutuphaneEntities5 db = new DbKutuphaneEntities5();
        public ActionResult Index()
        {
            var deger = db.TBL_PERSONEL.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TBL_PERSONEL prsn)
        { 
            if(!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBL_PERSONEL.Add(prsn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var prsn = db.TBL_PERSONEL.Find(id);
            db.TBL_PERSONEL.Remove(prsn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var prsn = db.TBL_PERSONEL.Find(id);
            return View("PersonelGetir", prsn);
        }
        public ActionResult PersonelGüncelle(TBL_PERSONEL p)
        {
            var prsn = db.TBL_PERSONEL.Find(p.ID);
            prsn.PersonelAdSoyad = p.PersonelAdSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}