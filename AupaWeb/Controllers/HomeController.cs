using AupaWeb.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AupaWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            List<PostDataObject> postList;
            postList = sqlServerConnector.getTopPostsList(3);
            ViewBag.ListOfPosts = postList;
            return View(postList);
        }

        public ActionResult NewPost()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}