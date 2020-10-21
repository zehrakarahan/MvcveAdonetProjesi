using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTekKatman.Models;

namespace WebTekKatman.Controllers
{
    public class UrunController : Controller
    {
        MvcDB db = new MvcDB();
        // GET: Urun
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UrunDetay(int id)
        {
            var ali=db.Urunler.Where(x => x.ID == id).FirstOrDefault();
            return View(ali);
        }
    }
}