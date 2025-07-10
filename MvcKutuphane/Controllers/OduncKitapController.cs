using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncKitapController : Controller
    {
        // GET: OduncKitap

        DbKutuphaneEntities5 db = new DbKutuphaneEntities5();
        public ActionResult Index()
        {
            var liste = db.TBL_HAREKET.Where(x=>x.IslemDurum==false).ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBL_HAREKET p)
        {
            db.TBL_HAREKET.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Odunciade(int id)
        {
            var odn = db.TBL_HAREKET.Find(id);
            DateTime d1 = DateTime.Parse(odn.KitapİadeTarih.ToString());
            DateTime d2 = Convert.ToDateTime((DateTime.Now.ToShortDateString()));
            TimeSpan d3 = d2-d1; //TimeSpan, iki DateTime nesnesi arasındaki zaman farkını verir.
            ViewBag.ceza = d3.TotalDays;
            return View("Odunciade", odn);
        }

        public ActionResult OduncKitapGuncelle(TBL_HAREKET p)
        {
            var hrkt = db.TBL_HAREKET.Find(p.HAREKETID);
            hrkt.UyeGetirdigiTarih = p.UyeGetirdigiTarih;
            hrkt.IslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}