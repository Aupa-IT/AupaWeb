using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AupaWeb.Models
{
    public class IndexModel
    {
        public IEnumerable<PostDataObject> PostDataObjects { get; set; }
        public IEnumerable<CarouselDataObject> CarouselDataObjects { get; set; }
    }
}