using AupaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AupaWeb.Controllers
{
    public class PostController : Controller
    {

        private PostDataObject postObject = new PostDataObject();
        private readonly SQLServerConnector sqlServerConnector = new SQLServerConnector();
        public ActionResult AddNewPost()
        {
            ViewBag.Message = sqlServerConnector.GetHashCode();
            return View();
        }

        public ActionResult Details(int? id)
        {
            return View();
        }
    }
}
