using AupaWeb.Models;
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
            List<PostDataObject> listPosts = new List<PostDataObject>();
            listPosts = getPosts();

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
        public ActionResult Create([Bind(Include = "aaa01,aaa02,aaa03,aaa04")] PostDataObject postDataObject)
        {
            SQLServerConnector sQLServer = new SQLServerConnector();
            //if (ModelState.IsValid)
            //{
            //    return RedirectToAction("AddNewPost");
            //}
            List<PostDataObject> listPosts = new List<PostDataObject>();
            listPosts = getPosts();
            listPosts.Add(postDataObject);
            ViewBag.ListOfPosts = listPosts;
            return View("AddNewPost", listPosts);
        }


        private List<PostDataObject> getPosts()
        {
            PostDataObject fakePost;
            List<PostDataObject> fakePosts = new List<PostDataObject>();

            fakePost = new PostDataObject();
            fakePost.Aaa01 = "1234567";
            fakePost.Aaa02 = "First Fake Title";
            fakePost.Aaa03 = "First Fake Content";
            fakePost.Aaa04 = DateTime.Now;
            fakePosts.Add(fakePost);

            fakePost = new PostDataObject();
            fakePost.Aaa01 = "7654321";
            fakePost.Aaa02 = "Second Fake Title";
            fakePost.Aaa03 = "Second Fake Content";
            fakePost.Aaa04 = DateTime.Now;
            fakePosts.Add(fakePost);

            fakePost = new PostDataObject();
            fakePost.Aaa01 = "9876543";
            fakePost.Aaa02 = "Third Fake Title";
            fakePost.Aaa03 = "Third Fake Content";
            fakePost.Aaa04 = DateTime.Now;
            fakePosts.Add(fakePost);

            return fakePosts;
        }
    }
}
