using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AupaWeb.Models
{
    public class CarouselDataObject
    {
        private String aaz01;
        private String aaz02;
        private String aaz03;
        private String aaz05;
        private bool active;

        public string Aaz01 { get => aaz01; set => aaz01 = value; }
        public string Aaz02 { get => aaz02; set => aaz02 = value; }
        public string Aaz03 { get => aaz03; set => aaz03 = value; }
        public string Aaz05 { get => aaz05; set => aaz05 = value; }
        public bool Active { get => active; set => active = value; }
    }
}