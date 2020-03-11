using AupaWeb.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AupaWeb.Controllers
{
    public class UserController : Controller
    {
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost, ActionName("Sign_In")]
        [AllowAnonymous]
        public ActionResult SendLoginData(UserBasicObject model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            SQLServerConnector sqlServerConnector = new SQLServerConnector();
            UserBasicObject userBasicObject = sqlServerConnector.GetUserBasicData(model);

            if (userBasicObject == null)
            {
                return View("Index", "Home");
            }

            
            FormsAuthentication.SetAuthCookie(userBasicObject.Aba01, false);
            return RedirectToAction("AddNewPost", "Post");
        }
    }
}