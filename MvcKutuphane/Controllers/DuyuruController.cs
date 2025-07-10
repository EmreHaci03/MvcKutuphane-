using System; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DbKutuphaneEntities5 db = new DbKutuphaneEntities5();
        public ActionResult Index()
        {
            var degerler=db.TBL_DUYURULAR.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult DuyuruEkle(TBL_DUYURULAR p)
        {
            db.TBL_DUYURULAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruSil(int id)
        {
            var deger = db.TBL_DUYURULAR.Find(id);
            db.TBL_DUYURULAR.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruDetay(TBL_DUYURULAR p)
        {
            var duyuru = db.TBL_DUYURULAR.Find(p.ID);
            return View("DuyuruDetay",duyuru);
        }

        public ActionResult DuyuruGuncelle(TBL_DUYURULAR p)
        {
            var duyuru = db.TBL_DUYURULAR.Find(p.ID);
            duyuru.Kategori = p.Kategori;
            duyuru.Icerik = p.Icerik;
            duyuru.Tarih = p.Tarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}