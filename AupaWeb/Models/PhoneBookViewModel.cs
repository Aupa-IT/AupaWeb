using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AupaWeb.Models
{
    public class PhoneBookViewModel
    {
        List<SelectListItem> selectListItems = new List<SelectListItem>();
        List<UserBasicDataObject> userBasicDataObjects = new List<UserBasicDataObject>();
        private string colName;
        private string colValue;

        public List<SelectListItem> SelectListItems { get => selectListItems; set => selectListItems = value; }
        public List<UserBasicDataObject> UserBasicDataObjects { get => userBasicDataObjects; set => userBasicDataObjects = value; }
        public string ColName { get => colName; set => colName = value; }
        public string ColValue { get => colValue; set => colValue = value; }
    }
}