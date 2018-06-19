using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Plejehjem_Opgave_CSharp.Models;

namespace Plejehjem_Opgave_CSharp.Controllers
{
    public class HomeController : Controller
    {
    
    
        private  static  List<CitizensToBeVisitedToday> modelRuteplan = new List<CitizensToBeVisitedToday>();
      
      




        /// <summary>
        /// RutePlan() returns a view based on a model called "finalList".
        /// This finalList is a list with an object that contains all needed information
        /// It contains following:
        /// 1. vistingTimes: A way to see when the employee needs to be at a citizens
        /// 2. citizensIDToday The ID of the citizens we need to visit today
        /// 3. citizensNamesToday Name of the citizens we need to visit today
        /// 4. citizensAddressToday Address of the citizen
        /// 5. CPRNumbersToday CPRnumber of the citizen
        /// 6.findLatitudeToday finds the latitude based on the whereabouts of the citizens
        /// 7. findLongtitudeToday Same, but for longtitude
        /// </summary>
        /// <returns>RutePlan view with a finalList model</returns>

        public ActionResult RutePlan()
        {

            //since our original finalList is static, we need to basically set it to null
            //that way we dont get the same information when we refresh /ruteplan
          //  modelRuteplan = new List<CitizensToBeVisitedToday>();
            

            //since sessions are static and global they can be accessed anywhere.
            if (Session["UserID"] == null)
            {
                return RedirectToAction("../Account/Login");
            }
            else
            {

                //gets the date today
                var currentDate = DateTime.Now.Date;


                //currentUserID contains information about the ID of whom is logged into the system(which user account)
                int currentUserID = Int32.Parse((string) Session["UserID"]);

                string dateFormatted = currentDate.ToString("dd/MM/yyyy");


                using (var context = new MyDbContext())
                {


                    //adds every citizen ID to a list
                

                        modelRuteplan = (from f in context.FullCitizensInfos
                            join g in context.GoogleMapsInformations on f.citizensID equals g.citizensRefId
                            join s in context.Schedules on f.citizensID equals s.citizensRefId

                            where s.userAccountRef == currentUserID
                            where s.DateForVisiting == currentDate
                            where f.citizensID == s.citizensRefId

                            select new CitizensToBeVisitedToday()
                            {
                                vistingTimesToday = s.visitingTime,
                                dateToday = dateFormatted,
                                CPRNumber = f.CPRNumber,
                                citizensName = f.firstName,
                                address = f.address,
                                latitude = g.Latitude,
                                longtitude = g.Longtitude
                            }

                        ).ToList();


                        //sets our array into an object, so we can pass it to the view via a model.


                        //TODO: INSTEAD OF RETURNING CITIZENS, RETURN THE CURRENT USER. CHECK OUT LINK BELOW
                        //https://www.c-sharpcorner.com/UploadFile/7d3362/pass-data-from-controller-to-view-in-Asp-Net-mvc/
                        //TODO: What we need to do is pass the information of currentuser and datetime to our view.
                        // return View(finalList);

                    
                }
            }

            if (modelRuteplan != null && modelRuteplan.Count > 0)
            {
                return View(modelRuteplan);
            }

            return View("RuteplanNotAvailable");

        }


        public JsonResult GetAllLocations()
        {
        
       // var data = context.GoogleMapsInformations.ToList();
            return Json(modelRuteplan, JsonRequestBehavior.AllowGet);

         
        }



        public ActionResult details_VP()
        {
            {
                if (Session["UserID"] == null)
                {
                    //redirect to login if userid is empty
                    return RedirectToAction("../Account/Login");
                }
                else
                {
                    //returns the view you seek
                    using (MyDbContext Mydb = new MyDbContext())
                    {
                        //Fills the model, as of now the model is being filled with everything since there is 
                        //nothing chaining the data to the current user, this could easily be fixed
                        //with some code that selected the user and then joined the other tables on to that user.
                        var model = (from cc in Mydb.CitizensContacts
                            join sche in Mydb.Schedules on cc.citizensRefId equals sche.citizensRefId
                            join fci in Mydb.FullCitizensInfos on cc.citizensRefId equals fci.citizensID
                            select new ClientWork()
                            {
                                contact_Job = cc.JobTitle,
                                contact_Name = cc.FirstName + cc.LastName,
                                contact_Phone = cc.PhoneNumber,
                                contact_Email = cc.email,
                                contact_OtherInfo = cc.otherInformation,
                                rel_Relationship = cc.relationToCitizens,
                                vis_Date = sche.visitingTime,

                            }).ToList<ClientWork>(); //Makes it to a generic list that can then be accessed by the view.

                        return View(model);
                    }

                    // Session["Username"] = usr.Username.ToString();
                }

            }
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
            {
                return RedirectToAction("../Account/Login");
            }
            else
            {
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
            {

              int currentuserID = Int32.Parse((String)Session["UserID"]);

                using (var context = new MyDbContext())
                {
                    var vistingTimesoftheweek = from s in context.Schedules
                                                where s.userAccountRef == currentuserID

                                                select s.visitingTime;



                    return View("skema");
                }
            }
        }
    }
}