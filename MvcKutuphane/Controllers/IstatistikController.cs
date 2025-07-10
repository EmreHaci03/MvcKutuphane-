using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        DbKutuphaneEntities5 db = new DbKutuphaneEntities5();
        // GET: Istatistik
        public ActionResult Index()
        {
            var deger1 = db.TBL_UYELER.Count();
            var deger2 = db.TBL_KİTAP.Count();
            var deger3 = db.TBL_KİTAP.Where(x=>x.KitapDurum==false).Count();
            var deger4 = db.TBL_CEZALAR.Sum(x => x.Para);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult LinqKart()
        {
            var kitapsayi = db.TBL_KİTAP.Count();
            var uyesayi = db.TBL_UYELER.Count();
            var iadekitap = db.TBL_KİTAP.Where(x => x.KitapDurum == false).Count();
            var kasamiktar = db.TBL_KASA.Sum(x => x.Tutar);
            var kategorisayi = db.TBL_KATEGORİ.Count();
            var yazarkitap = db.enfazlakitapyazar().FirstOrDefault();
            var personelsayi = db.TBL_PERSONEL.Count();
            var yayinevisayi = db.TBL_KİTAP.Where(x => x.KitapYayınEvi != null)
                .Select(x => x.KitapYayınEvi)
                .Distinct()
                .Count();
            ViewBag.dgr1 = kitapsayi;
            ViewBag.dgr2 = uyesayi;
            ViewBag.dgr3 = iadekitap;
            ViewBag.dgr4 = kasamiktar;
            ViewBag.dgr5 = kategorisayi;
            ViewBag.dgr6=yazarkitap;
            ViewBag.dgr7=yayinevisayi;
            //ViewBag.dgr8=yayinevisayi;
            ViewBag.dgr9= personelsayi;

            return View();
        }
    }
}