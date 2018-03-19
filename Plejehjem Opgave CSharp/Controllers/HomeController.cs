using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plejehjem_Opgave_CSharp.Models;

namespace Plejehjem_Opgave_CSharp.Controllers
{
    public class HomeController : Controller
    {
        private List<CitizensInformation> citizens;

        public HomeController()
        {

            citizens = new List<CitizensInformation>()
            {
                //following is dummy data. 
                //TODO: This is to be replaced with data from Database
                new CitizensInformation()
                {
                    address = "Lygten 37",
                    citizensName = "Ole Kristiansen",
                    CPRNumber = "165453452",
                    visitingTime = "12/12-2017 09:22"
                },
                new CitizensInformation()
                {
                    address = "Brandstrupvej 4",
                    citizensName = "Kurt jensen",
                    CPRNumber = "2345234513",
                    visitingTime = "12/12-2017 10:30"
                },

                new CitizensInformation()
                {
                    address = "William boothsvej 17",
                    citizensName = "Hans Andersen",
                    CPRNumber = "463456345",
                    visitingTime = "12/12-2017 11:42"
                }
               

            };
        }


        
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account/Login");
        }

            public ActionResult RutePlan()
        {

            return View(citizens);


        }

        public ActionResult Details_VP()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
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