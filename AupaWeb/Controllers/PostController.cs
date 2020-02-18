using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AupaWeb.Controllers
{
    public class PostController : Controller
    {
        public ActionResult AddNewPost()
        {
            return View();
        }
    }
}
