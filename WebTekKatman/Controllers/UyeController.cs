using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTekKatman.Models;

namespace WebTekKatman.Controllers
{
    public class UyeController : Controller
    {
        MvcDB db = new MvcDB();
        // GET: Uye
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UyeOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeOl(Uyeler uye)
        {
            string mesaj = "";
            if (uye.Adi == null)
            {
                mesaj = "kullanıcı adi bos birakilamaz";
                return RedirectToAction("UyeOl", "Uye");
            }
            else if (uye.Email == null)
            {
                mesaj = "kullanıcı email bos birakilamaz";
                return RedirectToAction("UyeOl", "Uye");
            }
            else if (uye.Soyadi == null)
            {
                mesaj = "kullanıcı soyadı bos birakilamaz";
                return RedirectToAction("UyeOl", "Uye");
            }
            else if (uye.Sifre == null)
            {
                mesaj = "kullanıcı sifre bos bırakilamaz";
                return RedirectToAction("UyeOl", "Uye");
            }
            db.Uyeler.Add(uye);
            db.SaveChanges();
            string deger = uye.Adi + " " + uye.Soyadi;
            int isim = uye.ID;
            Session["ali"] = deger;
            Session["isim"] = isim;
            Session["veli"] = uye.Email;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UyeGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeGiris(string Email, string sifre)
        {
            string mesaj = "";
            var deger = db.Uyeler.Where(x => x.Email == Email && x.Sifre == sifre).FirstOrDefault();
            if (deger == null)
            {
                mesaj = "kullanici adi veya sifrenin yanlıs lutfen kontrol ediniz";
                return RedirectToAction("UyeGiris", "Uye");
            }
            else
            {
                string adi = deger.Adi + " " + deger.Soyadi;
                int isim = deger.ID;
                Session["ali"] = adi;
                Session["isim"] = isim;
                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult CikisYap()
        {
            Session["ali"] = null;
            Session["veli"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
       
}