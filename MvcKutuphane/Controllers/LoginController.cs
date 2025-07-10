using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    public class LoginController : Controller
    {
        DbKutuphaneEntities5 db = new DbKutuphaneEntities5();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TBL_UYELER p)
        {
            var bilgiler = db.TBL_UYELER.FirstOrDefault(x => x.UyeMail == p.UyeMail && x.UyeSifre == p.UyeSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.UyeMail, false);
                Session["Mail"] = bilgiler.UyeMail;
                //Session["ID"] = bilgiler.ID.ToString();
                //Session["AdSoyad"] = bilgiler.UyeAdSoyad.ToString();
                //Session["KullaniciAd"] = bilgiler.UyeKullaniciAd.ToString();
                //Session["Sifre"] = bilgiler.UyeSifre.ToString();
                //Session["Telefon"] = bilgiler.UyeTelefon.ToString();
                //Session["Okul"] = bilgiler.UyeOkul.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }
        }
    }
