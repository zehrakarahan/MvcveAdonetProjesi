using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTekKatman.Models;

namespace WebTekKatman.Controllers
{
    public class UrunlerController : Controller
    {
        MvcDB db = new MvcDB();
        // GET: Urunler
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UrunDetay(int id)
        {
           
            
            return View(db.Urunler.Where(x => x.ID == id).FirstOrDefault());
           
        }
    }
}