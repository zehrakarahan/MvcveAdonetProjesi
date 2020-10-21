using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTekKatman.Models;

namespace WebTekKatman.Sepetislemleri
{
    public class Sepet
    {
       

        public static Sepet AktifSepet
        {
            get{
                HttpContext db =HttpContext.Current;
                if (db.Session["AktifSepet"] == null)
                    db.Session["AktifSepet"] = new Sepet();
                return (Sepet)db.Session["AktifSepet"];
            }
        }
        private List<SepetItem> urunler = new List<SepetItem>();

        public List<SepetItem> Urunler
        {
            get
            {
                return urunler;
            }
            set { urunler = value; }
        }

        public void SepeteEkle(SepetItem si)
        {
            if(HttpContext.Current.Session["AktifSepet"]!=null)
            {
                Sepet s = (Sepet)HttpContext.Current.Session["AktifSepet"];
                if (s.Urunler.Any(x => x.Urun.ID == si.Urun.ID))
                {
                    s.Urunler.FirstOrDefault(x => x.Urun.ID == si.Urun.ID).Adet++;
                }
                else
                {
                    s.Urunler.Add(si);
                }
            }
            else
            {
                Sepet s = new Sepet();
                s.Urunler.Add(si);
                HttpContext.Current.Session["AktifSepet"] = s;
            }
           
        }

        public decimal TotalTutar
        {
            get
            {
                return Urunler.Sum(x=>x.Tutar);
            }
        }
        public class SepetItem
        {
            public Urunler  Urun { get; set; }

            public int Adet { get; set; }

            public double Indirim { get; set; }

            public decimal Tutar {
                get
                {
                    return (decimal)Urun.Fiyat * Adet*(decimal)(1-Indirim);
                }
            }
        }
    }
}