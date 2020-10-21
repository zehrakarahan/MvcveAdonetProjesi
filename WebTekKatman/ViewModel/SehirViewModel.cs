using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTekKatman.ViewModel
{
    public class SehirViewModel
    {
        public SehirViewModel()
        {
            this.IlceList = new List<SelectListItem>();
            IlceList.Add(new SelectListItem {  Text="Seciniz",Value=""});
        }
        public int SehirID { get; set; }

        public int IlceID { get; set; }

        public List<SelectListItem> SehirList { get; set; }

        public List<SelectListItem> IlceList { get; set; }


    }
}