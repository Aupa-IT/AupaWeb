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
            string sqlWhereString;
            string sqlAndString;
            if (viewModel.ColValue == "" || viewModel.ColValue.Length==0)
            {
                sqlWhereString = " 1= 1";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";
            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }

                

            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        public ActionResult BackToPhoneBookSearch()
        {
            PhoneBookViewModel phoneBookViewModel = (PhoneBookViewModel)TempData["phoneBookViewModel"];
            return View("PhoneBookSearch", phoneBookViewModel);
        }

        public ActionResult SearchPhoneBookButton(string Zza06)
        {
            string sqlAndString;
            
            if (Zza06 == "" || Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + Zza06 + "' ";
            }

            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(" 1=1 ", sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

    }
}