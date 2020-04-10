using AupaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AupaWeb.Controllers
{
    public class PhonebookController : Controller
    {
        // GET: Phonebook
        public ActionResult PhoneBookSearch()
        {
            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();
            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            return View(phoneBookViewModel);
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        public ActionResult SearchPhoneBook(PhoneBookViewModel viewModel)
        {
            string colName = viewModel.ColName;
            string colValue = viewModel.ColValue;
            string sqlString = " zza05 = '" + colValue + "'";

            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataObjects = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlString);
            
            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch"); ;
        }

        public ActionResult BackToPhoneBookSearch()
        {
            PhoneBookViewModel phoneBookViewModel = (PhoneBookViewModel)TempData["phoneBookViewModel"];
            return View("PhoneBookSearch", phoneBookViewModel);
        }

    }
}