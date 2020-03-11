using AupaWeb.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.WebPages;

namespace AupaWeb.Controllers
{
    public class PostController : Controller
    {
        [Authorize]
        public ActionResult AddNewPost()
        {
            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            //PageBean pageBean = new PageBean();
            List<PostDataObject> listPosts;
            List<PageBean> pageNumberList;
            //listPosts = sqlServerConnector.GetPostsList();
            int pageTotalCount = sqlServerConnector.GetTotalCount();

            PageOperation pageOperation = new PageOperation(pageTotalCount);
            int currentPage = 1;
            pageNumberList = pageOperation.GetPageNumberList();
            int pageCount = pageOperation.GetPageCount();
            int startPageNum = pageOperation.GetStartNumber(currentPage);
            int endPageNum = pageOperation.GetEndNumber();
            int previousPageNumber = 1;
            int nextPageNumber = previousPageNumber + 1;
            listPosts = sqlServerConnector.GetLimitPostsList("0", "5");

            PostDataViewModel postDataViewModel = new PostDataViewModel();
            postDataViewModel.PostDataList = listPosts;
            postDataViewModel.PageNumberList = pageNumberList;
            postDataViewModel.PageCount = pageCount;
            postDataViewModel.CurrentPage = currentPage;
            postDataViewModel.StrPageNum = startPageNum;
            postDataViewModel.EndPageNum = endPageNum;
            postDataViewModel.PreviousPageNumber = previousPageNumber;
            postDataViewModel.NextPageNumber = nextPageNumber;
            postDataViewModel.FirstPage = true;
            postDataViewModel.LastPage = false;

            //ViewBag.ListOfPosts = listPosts;
            //return View(listPosts);
            return View(postDataViewModel);
        }
        [Authorize]
        public ActionResult ToPage(String postID)
        {
            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            //PageBean pageBean = new PageBean();
            List<PostDataObject> listPosts;
            List<PageBean> pageNumberList;
            //listPosts = sqlServerConnector.GetPostsList();
            int pageTotalCount = sqlServerConnector.GetTotalCount();

            PageOperation pageOperation = new PageOperation(pageTotalCount);
            int currentPage = int.Parse(postID);
            pageNumberList = pageOperation.GetPageNumberList();
            int pageCount = pageOperation.GetPageCount();
            int startPageNum = pageOperation.GetStartNumber(currentPage);
            int endPageNum = pageOperation.GetEndNumber();
            int previousPageNumber = 1;
            int nextPageNumber = previousPageNumber + int.Parse(postID);
            if (currentPage == 1)
            {
                startPageNum = 0;
            }
            listPosts = sqlServerConnector.GetLimitPostsList(startPageNum.ToString(), "5");

            PostDataViewModel postDataViewModel = new PostDataViewModel();
            postDataViewModel.PostDataList = listPosts;
            postDataViewModel.PageNumberList = pageNumberList;
            postDataViewModel.PageCount = pageCount;
            postDataViewModel.CurrentPage = currentPage;
            postDataViewModel.StrPageNum = startPageNum;
            postDataViewModel.EndPageNum = endPageNum;
            postDataViewModel.PreviousPageNumber = previousPageNumber;
            postDataViewModel.NextPageNumber = nextPageNumber;
            if (startPageNum == 0)
            {
                postDataViewModel.FirstPage = true;
            }
            else
            {
                postDataViewModel.FirstPage = false;
            }
            if(currentPage == pageNumberList.Count)
            {
                postDataViewModel.LastPage = true;
            }
            else
            {
                postDataViewModel.LastPage = false;
            }
            

            TempData["postDataViewModel"] = postDataViewModel;

            return Redirect("BackToAddNewPost");
        }

        public ActionResult BackToAddNewPost()
        {
            PostDataViewModel postDataViewModel = (PostDataViewModel)TempData["postDataViewModel"];
            return View("AddNewPost", postDataViewModel);
        }

        [Authorize]
        public ActionResult CreatePost()
        {
            return View();
        }
        // POST: Students/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "aaa06,aaa07")] PostDataObject postDataObject)
        {
            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            //List<PostDataObject> listPosts;
            //listPosts = sqlServerConnector.getPostsList();

            postDataObject.Aaa01 = DateTime.Now.ToString("yyyyMMddHHmmss");
            postDataObject.Aaa02 = "";
            postDataObject.Aaa03 = "TEST";
            postDataObject.Aaa04 = DateTime.Now.ToString("yyyy-MM-dd");
            postDataObject.Aaa05 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            postDataObject.Aaa08 = "";

            String result = sqlServerConnector.InsertPostData(postDataObject);

            return RedirectToAction("AddNewPost","Post");

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
            listPosts = sqlServerConnector.GetPostsListOnDemand(sqlCriteria);
            ViewBag.ListOfPosts = listPosts;
            return View("ConfirmDelete", listPosts);
        }//End of DeletePost

        [HttpPost, ActionName("ConfirmedDelete")]
        public ActionResult ConfirmedDeletePost(String postID)
        {
            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            List<PostDataObject> listPosts = new List<PostDataObject>();
            String result = sqlServerConnector.ConfirmedDelete(postID);
            if (result == "SUCCESS")
            {
                listPosts = sqlServerConnector.GetPostsList();
            }
            ViewBag.ListOfPosts = listPosts;

            //return View("AddNewPost", listPosts);
            return RedirectToAction("AddNewPost", "Post");
        }// End of ConfirmedDeletePost

        public ActionResult EditPost(String postID)
        {
            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            List<PostDataObject> listPosts;
            PostDataObject postDataObjectForEdit;
            String sqlCriteria = "aaa01 = '" + postID + "'";

            listPosts = sqlServerConnector.GetPostsListOnDemand(sqlCriteria);

            postDataObjectForEdit = listPosts[0];
            //ViewBag.ListOfPosts = listPosts;
            ViewBag.PostDataForEdit = postDataObjectForEdit;

            return View("EditPost", postDataObjectForEdit);
        }

        [HttpPost, ActionName("ConfirmedEdit")]
        public ActionResult UpdatePost([Bind(Include ="Aaa01,Aaa06,Aaa07")] PostDataObject postDataObject)
        {
            SQLServerConnector sqlServerConnector = new SQLServerConnector();

            postDataObject.Aaa05 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            String result = sqlServerConnector.ConfirmedEdit(postDataObject);
            List<PostDataObject> listPosts = new List<PostDataObject>();
            if (result == "SUCCESS")
            {
                listPosts = sqlServerConnector.GetPostsList();
            }

            ViewBag.ListOfPosts = listPosts;

            //return View("AddNewPost", listPosts);
            return RedirectToAction("AddNewPost", "Post");
        }

    }
}
