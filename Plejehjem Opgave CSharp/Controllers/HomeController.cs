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
        private List<CitizensInformation> citizens;
        private static List<CitizensToBeVisitedToday> finalList = new List<CitizensToBeVisitedToday>();


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
                finalList = new List<CitizensToBeVisitedToday>();


           MyDbContext db = new MyDbContext();
                List<string> vistingTimes = new List<string>();
                List<int> citizensIDToday = new List<int>();
                List<string> citizensNamesToday = new List<string>();
                List<string> citizensAddressToday = new List<string>();
                List<string> CPRNumbersToday = new List<string>();

                List<double> findLatitudeToday = new List<double>();
                List<double> findLongtitudeToday = new List<double>();

                

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
                int currentUserID = Int32.Parse((string)Session["UserID"]);


                using (var context = new MyDbContext())
                {
                  

                    
                    
                    //If the currentuserID(the ID of whoever is logged in) is found in the database (useraccountref),
                    //and the DateForVisiting(the date they need to visit) is equal to currentDate(today),
                    //then select all the times(clock) for when the employee needs to be there.
                    var vistingTimesToday = from s in context.Schedules
                       where s.userAccountRef == currentUserID
                      where s.DateForVisiting == currentDate
                                                  
                        select s.visitingTime;


                    //gets the ID of the citizen to be visited today
                    //Distinct removes any duplicates.
                    var citizensToBeVisited = (from s in context.Schedules
                        where s.userAccountRef == currentUserID
                        where s.DateForVisiting == currentDate

                        select  s.citizensRefId).Distinct();





                    //THIS DATA IS WHAT WE NEED!!
                    foreach (var data in vistingTimesToday)
                    {
                        vistingTimes.Add(data);
                        
                       
                    }

                    //adds every citizen ID to a list
                    foreach (var citizensIDData in citizensToBeVisited)
                    {
                        citizensIDToday.Add(citizensIDData);

                        //gets the name that corrosponds to the ID
                        var findCitizensNamesToday = from f in context.FullCitizensInfos
                            where f.citizensID == citizensIDData
                            select f.firstName;
                        

                        //there is always only loop through this once, since the outer loop gives ONE result each time
                        //only need the loop to get the specific data
                        foreach (var data2 in findCitizensNamesToday)
                        {
                            citizensNamesToday.Add(data2);
                        }

                        //gets all the addresses of the citizens today
                        var findCitizensAddressToday = from f in context.FullCitizensInfos
                            where f.citizensID == citizensIDData
                            select f.address;

                        foreach (var data3 in findCitizensAddressToday)
                        {
                            citizensAddressToday.Add(data3);
                        }

                        //gets the cprnumbers of the citizens that needs to be visitewd today..
                        var findCPRNumberToday = from f in context.FullCitizensInfos
                            where f.citizensID == citizensIDData
                            select f.CPRNumber;


                        foreach (var data4 in findCPRNumberToday)
                        {
                            CPRNumbersToday.Add(data4);
                        }

                        var findLatitude = from g in context.GoogleMapsInformations
                            where g.citizensRefId == citizensIDData
                            select g.Latitude;

                        foreach (var data5 in findLatitude)
                        {
                            findLatitudeToday.Add(data5);
                        }

                        var findLongtitude = from g in context.GoogleMapsInformations
                            where g.citizensRefId == citizensIDData
                            select g.Longtitude;

                        foreach (var data6 in findLongtitude)
                        {
                            findLongtitudeToday.Add(data6);
                        }


                    }

       
                }

                //formats away the default clock timer and coverts Date to string
                string dateFormat = currentDate.ToString("dd/MM/yyyy");


                

                for (int i = 0; i < vistingTimes.Count; i++)
                {
                    try
                    {
                        finalList.Add(new CitizensToBeVisitedToday
                        {
                            vistingTimesToday = vistingTimes[i],
                            dateToday = dateFormat,
                            CPRNumber = CPRNumbersToday[i],
                            citizensName = citizensNamesToday[i],
                            address = citizensAddressToday[i],
                            latitude = findLatitudeToday[i],
                            longtitude = findLongtitudeToday[i]
                        });
                    }
                    //in case the user has no one to visit today
                    catch (System.ArgumentOutOfRangeException)
                    {
                        finalList = null;
                    }
               
                }



                if (finalList != null)
                {
                    return View(finalList);
                }

                return View("RuteplanNotAvailable");

                //sets our array into an object, so we can pass it to the view via a model.
            

                //TODO: INSTEAD OF RETURNING CITIZENS, RETURN THE CURRENT USER. CHECK OUT LINK BELOW
                //https://www.c-sharpcorner.com/UploadFile/7d3362/pass-data-from-controller-to-view-in-Asp-Net-mvc/
                //TODO: What we need to do is pass the information of currentuser and datetime to our view.
               // return View(finalList);

            }
        }


        public JsonResult GetAllLocations()
        {
        


       // var data = context.GoogleMapsInformations.ToList();
            return Json(finalList, JsonRequestBehavior.AllowGet);

         
        }



        public ActionResult details_VP()
        {
            if (Session["UserID"] == null)
            {//redirect to login if userid is empty
                return RedirectToAction("../Account/Login");
            }
            else
            {//returns the view you seek
                return View();

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
                return View("skema");
            }
        }
    }
}