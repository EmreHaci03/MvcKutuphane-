using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    
    public class KayitOlController : Controller
    {
        DbKutuphaneEntities5 db = new DbKutuphaneEntities5();
        // GET: KayitOl

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBL_UYELER p)
        {

            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return View();

        }
    }
}