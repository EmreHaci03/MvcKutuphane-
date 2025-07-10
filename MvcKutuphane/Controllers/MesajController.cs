using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        DbKutuphaneEntities5 db = new DbKutuphaneEntities5();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBL_MESAJLAR.Where(x => x.Alici == uyemail).ToList() ;
            return View(mesajlar);
        }

        public ActionResult GidenMesaj()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBL_MESAJLAR.Where(x => x.Gonderen == uyemail).ToList();
            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj(){

            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TBL_MESAJLAR p)
        {
            var uyemail = (string)Session["Mail"].ToString();
            p.Gonderen = uyemail.ToString();
            p.Tarih=DateTime.Parse(DateTime.Now.ToString());    
            db.TBL_MESAJLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("GidenMesaj");
        }

    }
}