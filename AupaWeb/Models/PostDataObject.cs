using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AupaWeb.Models
{
    public class PostDataObject
    {
        private string rowid;
        private string aaa01;
        private string aaa02;
        private string aaa03;
        private DateTime aaa04;
        private DateTime aaa05;
        private string aaa06;
        private string aaa07;
        private string aaa08;

        public string Rowid { get => rowid; set => rowid = value; }
        public string Aaa01 { get => aaa01; set => aaa01 = value; }
        public string Aaa02 { get => aaa02; set => aaa02 = value; }
        public string Aaa03 { get => aaa03; set => aaa03 = value; }
        public DateTime Aaa04 { get => aaa04; set => aaa04 = value; }
        public DateTime Aaa05 { get => aaa05; set => aaa05 = value; }
        public string Aaa06 { get => aaa06; set => aaa06 = value; }
        public string Aaa07 { get => aaa07; set => aaa07 = value; }
        public string Aaa08 { get => aaa08; set => aaa08 = value; }
    }
}