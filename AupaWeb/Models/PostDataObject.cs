using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AupaWeb.Models
{
    public class PostDataObject
    {
        private string aaa01;
        private string aaa02;
        private string aaa03;
        private DateTime aaa04;

        public string Aaa01 { get => aaa01; set => aaa01 = value; }
        public string Aaa02 { get => aaa02; set => aaa02 = value; }
        public string Aaa03 { get => aaa03; set => aaa03 = value; }
        public DateTime Aaa04 { get => aaa04; set => aaa04 = value; }
    }
}