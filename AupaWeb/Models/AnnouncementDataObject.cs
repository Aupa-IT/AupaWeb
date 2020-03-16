using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AupaWeb.Models
{
    public class AnnouncementDataObject
    {
        private String aay01;
        private String aay02;
        private String aay03;
        private String aay04;
        private bool active;

        public string Aay01 { get => aay01; set => aay01 = value; }
        public string Aay02 { get => aay02; set => aay02 = value; }
        public string Aay03 { get => aay03; set => aay03 = value; }
        public string Aay04 { get => aay04; set => aay04 = value; }
        public bool Active { get => active; set => active = value; }
    }
}