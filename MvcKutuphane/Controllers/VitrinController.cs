using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;

namespace MvcKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        DbKutuphaneEntities5 db=new DbKutuphaneEntities5();
        // GET: Vitrin

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs=new Class1();
            cs.deger1 = db.TBL_KİTAP.ToList();
            cs.deger2 = db.TBL_HAKKİMİZDA.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBL_ILETISIM p)
        {
            db.TBL_ILETISIM.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}