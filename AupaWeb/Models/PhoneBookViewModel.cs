using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AupaWeb.Models
{
    public class PhoneBookViewModel
    {
        private string colValue;
        private string zza06;
        List<SelectListItem> selectListItems = new List<SelectListItem>();
        List<UserBasicDataObject> userBasicDataList = new List<UserBasicDataObject>();

        public List<SelectListItem> SelectListItems { get => selectListItems; set => selectListItems = value; }
        public List<UserBasicDataObject> UserBasicDataList { get => userBasicDataList; set => userBasicDataList = value; }
        public string ColValue { get => colValue; set => colValue = value; }
        public string Zza06 { get => zza06; set => zza06 = value; }
    }
}