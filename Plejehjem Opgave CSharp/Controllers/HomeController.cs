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


        [Authorize]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

       
            
            public ActionResult RutePlan()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("../Account/Login");
            }
            else
            {//returns the view you seek
                return View(citizens);

            }


        }

        
        public ActionResult details_VP()
        {
            if (Session["UserID"] == null)
            {//redirect to login if userid is empty
                return RedirectToAction("../Account/Login");


            }
            else
            {//returns the view you seek
                return View("brugerensdag");

            }

           // Session["Username"] = usr.Username.ToString();
        }
        public ActionResult Index()
        {
            return View();
        }

       
        /// <returns>A view that represents what the citizensen has been through during the day</returns>
        public ActionResult BrugerensDag()
        {
            ViewBag.Message = "Your application description page.";

            if (Session["UserID"] == null)
            {//redirect to login if userid is empty
                return RedirectToAction("../Account/Login");


            }
            else
            {//returns the view you seek
                return View("brugerensdag");
            }
        }

        /// <summary>
        /// Et fuldt referat over hvem der er blevet besøgt og hvornår.
        /// </summary>
        /// <returns>A view for all the citizens who has been visited</returns>
        public ActionResult HistorieNotater()
        {
            if (Session["UserID"] == null)
            {//redirect to login if userid is empty
                return RedirectToAction("../Account/Login");


            }
            else
            {//returns the view you seek
                return View("historienotater");
            }
        }


        /// <returns>A simple contact view</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


   
        /// <returns>A schedule for the employees</returns>
        public ActionResult Skema()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("../Account/Login");


            }
            else
            {//returns the view you seek
                return View("skema");
            }
        }
    }
}