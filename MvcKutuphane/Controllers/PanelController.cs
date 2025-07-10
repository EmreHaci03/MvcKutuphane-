using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using MvcKutuphane.Models.Entity;


namespace MvcKutuphane.Controllers
{
    
    public class PanelController : Controller
    {
        DbKutuphaneEntities5 db = new DbKutuphaneEntities5();
        // GET: Panel
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var mail = Session["Mail"]?.ToString();
            var uye=db.TBL_UYELER.FirstOrDefault(x=>x.UyeMail == mail); 
            if(uye == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(uye); //Model olarak gönderir.
            }
                
        }
        public ActionResult Kitap()
        {
            var kullanici = (string)Session["Mail"];
            var id=db.TBL_UYELER.Where(x=>x.UyeMail==kullanici).Select(t=>t.ID).FirstOrDefault();
            var degerler = db.TBL_HAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index(TBL_UYELER p)
        {

            var bilgiler = (string)Session["Mail"];
            var uye = db.TBL_UYELER.FirstOrDefault(x => x.UyeMail == bilgiler);
            uye.UyeAdSoyad = p.UyeAdSoyad;
            uye.UyeKullaniciAd = p.UyeKullaniciAd;
            uye.UyeSifre = p.UyeSifre;
            uye.UyeFotograf = p.UyeFotograf;
            uye.UyeTelefon = p.UyeTelefon;
            uye.UyeOkul = p.UyeOkul;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Duyurular()
        {
            var duyuruListe = db.TBL_DUYURULAR.ToList();
            return View(duyuruListe);
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Login");
        }
    }
}