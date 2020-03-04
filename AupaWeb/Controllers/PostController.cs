using AupaWeb.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.WebPages;

namespace AupaWeb.Controllers
{
    public class PostController : Controller
    {
        public ActionResult AddNewPost()
        {
            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            List<PostDataObject> listPosts;
            listPosts = sqlServerConnector.getPostsList();

            ViewBag.ListOfPosts = listPosts;
            return View(listPosts);
        }
        // GET: Students/Create
        public ActionResult CreatePost()
        {
            return View();
        }
        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aaa06,aaa07")] PostDataObject postDataObject)
        {
            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            List<PostDataObject> listPosts;
            listPosts = sqlServerConnector.getPostsList();

            postDataObject.Aaa01 = DateTime.Now.ToString("yyyyMMddHHmmss");
            postDataObject.Aaa02 = "";
            postDataObject.Aaa03 = "TEST";
            postDataObject.Aaa04 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            postDataObject.Aaa05 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            postDataObject.Aaa08 = "";

            String result = sqlServerConnector.InsertPostData(postDataObject);

            if (result == "SUCCESS")
            {
                listPosts.Add(postDataObject);
                ViewBag.ListOfPosts = listPosts;
                return View("AddNewPost", listPosts);
            }
            else
            {
                ViewBag.ListOfPosts = listPosts;
                return View("AddNewPost", listPosts);
            }

        }//Create

        public ActionResult DeletePost(String postID)
        {
            String sqlCriteria = "";
            if(postID != null && !postID.IsEmpty())
            {
                if (postID.StartsWith("*"))
                {
                    postID = postID.Remove(1, 1);
                }
                if (postID.EndsWith("*"))
                {
                    postID = postID.Remove(postID.Length-1, postID.Length);
                }
                sqlCriteria = "aaa01 LIKE '%" + postID+"%' ";
            }

            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            List<PostDataObject> listPosts;
            listPosts = sqlServerConnector.getPostsListOnDemand(sqlCriteria);
            ViewBag.ListOfPosts = listPosts;
            return View("ConfirmDelete", listPosts);
        }//End of DeletePost

        [HttpPost, ActionName("ConfirmedDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmedDeletePost(String postID)
        {
            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            List<PostDataObject> listPosts = new List<PostDataObject>();
            String result = sqlServerConnector.ConfirmedDelete(postID);
            if (result == "SUCCESS")
            {
                listPosts = sqlServerConnector.getPostsList();
            }
            ViewBag.ListOfPosts = listPosts;

            return View("AddNewPost", listPosts);
        }// End of ConfirmedDeletePost

        public ActionResult EditPost(String postID)
        {
            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            List<PostDataObject> listPosts;
            PostDataObject postDataObjectForEdit;
            String sqlCriteria = "aaa01 = '" + postID + "'";

            listPosts = sqlServerConnector.getPostsListOnDemand(sqlCriteria);

            postDataObjectForEdit = listPosts[0];
            //ViewBag.ListOfPosts = listPosts;
            ViewBag.PostDataForEdit = postDataObjectForEdit;

            return View("EditPost", postDataObjectForEdit);
        }

        [HttpPost, ActionName("ConfirmedEdit")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePost([Bind(Include ="Aaa01,Aaa06,Aaa07")] PostDataObject postDataObject)
        {
            SQLServerConnector sqlServerConnector = new SQLServerConnector();

            postDataObject.Aaa05 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            String result = sqlServerConnector.ConfirmedEdit(postDataObject);
            List<PostDataObject> listPosts = new List<PostDataObject>();
            if (result == "SUCCESS")
            {
                listPosts = sqlServerConnector.getPostsList();
            }

            ViewBag.ListOfPosts = listPosts;

            return View("AddNewPost", listPosts);
        }

    }
}
