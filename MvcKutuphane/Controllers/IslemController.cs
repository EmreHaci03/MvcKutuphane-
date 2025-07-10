using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        DbKutuphaneEntities5 db=new DbKutuphaneEntities5();
        public ActionResult Index()
        {
            var liste=db.TBL_HAREKET.Where(k=>k.IslemDurum==true).ToList();
            return View(liste);
        }
    }
}