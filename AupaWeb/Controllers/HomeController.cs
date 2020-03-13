using AupaWeb.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AupaWeb.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            IndexModel indexModel = new IndexModel();
            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            List<PostDataObject> postList;
            List<CarouselDataObject> carouselsLis;
            postList = sqlServerConnector.GetTopPostsList(3);
            carouselsLis = sqlServerConnector.GetTopCarouselList(5);
            indexModel.PostDataObjects = postList;
            indexModel.CarouselDataObjects = carouselsLis;
            //ViewBag.ListOfPosts = postList;
            //return View(postList);
            return View(indexModel);
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