using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTekKatman.Models;
using WebTekKatman.Sepetislemleri;
using static WebTekKatman.Sepetislemleri.Sepet;
using WebTekKatman.ViewModel;

namespace WebTekKatman.Controllers
{
    public class HomeController : Controller
    {
        MvcDB db = new MvcDB();
        // GET: Home
        public ActionResult Index()
        {
            var kadinayakabikategori = db.Kategoriler.FirstOrDefault(x => x.Adi == "Kadın Ayakkabı").ID;
            var kadinayakkabi = db.Urunler.Where(x => x.KategoriID == kadinayakabikategori).ToList();
            ViewBag.kadinayak = kadinayakkabi;
            var erkekayakkabikategori = db.Kategoriler.FirstOrDefault(x => x.Adi == "Erkek Ayakkabı").ID;
            var erkekayakkabi = db.Urunler.Where(x => x.KategoriID == erkekayakkabikategori).ToList();
            ViewBag.erkekayak = erkekayakkabi;
            var cocukayakkabikategori = db.Kategoriler.FirstOrDefault(x => x.Adi == "Çocuk Ayakkabı").ID;
            var cocukayakkabi = db.Urunler.Where(x => x.KategoriID == cocukayakkabikategori).ToList();
            ViewBag.cocukayak = cocukayakkabi;


            return View();
        }
       public void SepeteEkle(int id)
        {
            SepetItem s = new SepetItem();
            Urunler u = db.Urunler.FirstOrDefault(x=>x.ID==id);
            s.Urun = u;
            s.Adet = 1;
            s.Indirim = 0;
            Sepet se = new Sepet();
            se.SepeteEkle(s);
           
        }

        public PartialViewResult MiniSepet()
        {
            if(HttpContext.Session["AktifSepet"]!=null)
                return PartialView(HttpContext.Session["AktifSepet"]);
            return PartialView();
            
        }
        public ActionResult ÜrünDetay()
        {
            if (HttpContext.Session["AktifSepet"] != null)
                return View(HttpContext.Session["AktifSepet"]);
            return View();
        }
        public ActionResult SepetDevam()
        {
            SehirViewModel der = new SehirViewModel();
            List<Sehirler> sehir = db.Sehirler.OrderBy(f=>f.Adi).ToList();
            der.SehirList = (from s in sehir
                            select new SelectListItem
                            {
                                Text = s.Adi,
                                Value = s.ID.ToString()
                            }).ToList();
            der.SehirList.Insert(0,new SelectListItem { Value="",Text="Seciniz",Selected=true});
            return View(der);
        }

        public JsonResult IlceList(int id)
        {
            
            List<Ilceler> ilceList =db.Ilceler.Where(f => f.SehirID == id).OrderBy(f=>f.ID).ToList();
            List <SelectListItem> itemList = (from i in ilceList
                             select new SelectListItem
                             {
                                 Text = i.Adi,
                                 Value = i.ID.ToString()
                             }).ToList();
            return Json(itemList,JsonRequestBehavior.AllowGet);
        }

    }
}
