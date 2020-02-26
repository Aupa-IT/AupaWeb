using AupaWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AupaWeb.Controllers
{
    public class PostController : Controller
    {
        public ActionResult AddNewPost()
        {
            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            List<PostDataObject> listPosts = new List<PostDataObject>();
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
            SQLServerConnector sQLServer = new SQLServerConnector();
            List<PostDataObject> listPosts = new List<PostDataObject>();
            listPosts = getPosts();
            //if (ModelState.IsValid)
            //{
            //    return RedirectToAction("AddNewPost");
            //}
            postDataObject.Aaa01 = DateTime.Now.ToString("yyyyMMddHHmmss");
            postDataObject.Aaa02 = "";
            postDataObject.Aaa03 = "TEST";
            postDataObject.Aaa04 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            postDataObject.Aaa05 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            postDataObject.Aaa08 = "";

            String result = sQLServer.InsertPostData(postDataObject);

            if (result == "true"){
                listPosts.Add(postDataObject);
                ViewBag.ListOfPosts = listPosts;
                return View("AddNewPost", listPosts);
            }
            else
            {
                ViewBag.ListOfPosts = listPosts;
                return View("AddNewPost", listPosts);
            }

            
        }


        private List<PostDataObject> getPosts()
        {
            PostDataObject fakePost;
            List<PostDataObject> fakePosts = new List<PostDataObject>();

            fakePost = new PostDataObject();
            fakePost.Aaa01 = "1234567";
            fakePost.Aaa02 = "First Fake Title";
            fakePost.Aaa03 = "First Fake Content";
            //fakePost.Aaa04 = DateTime.Now;
            fakePosts.Add(fakePost);

            fakePost = new PostDataObject();
            fakePost.Aaa01 = "7654321";
            fakePost.Aaa02 = "Second Fake Title";
            fakePost.Aaa03 = "Second Fake Content";
            //fakePost.Aaa04 = DateTime.Now;
            fakePosts.Add(fakePost);

            fakePost = new PostDataObject();
            fakePost.Aaa01 = "9876543";
            fakePost.Aaa02 = "Third Fake Title";
            fakePost.Aaa03 = "Third Fake Content";
            //fakePost.Aaa04 = DateTime.Now;
            fakePosts.Add(fakePost);

            return fakePosts;
        }
    }
}
