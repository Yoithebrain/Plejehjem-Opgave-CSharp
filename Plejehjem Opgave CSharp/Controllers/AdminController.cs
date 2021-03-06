﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Plejehjem_Opgave_CSharp.Models;

namespace Plejehjem_Opgave_CSharp.Controllers
{


    public class AdminController : Controller
    {
        private static double latitude = 0;
        private static double longtitude = 0;


        // GET: Admin
        public ActionResult CreateCitizens()
        {
          
            return View();
        }


        /// <summary>
        /// Saves the information from the registre form to the database
        /// </summary>
        /// <param name="citizensInfo">Takes the entire form from /admin/CreateCitizens</param>
        /// <returns>View()</returns>
        [HttpPost]
        public ActionResult CreateCitizens(FullCitizensInfo citizensInfo)
        {

            //checks if the form is filled in correctly
            if (ModelState.IsValid)
            {
                using (MyDbContext db = new MyDbContext())
                {


                    db.FullCitizensInfos.Add(citizensInfo);

                    db.SaveChanges();

                    
                }
                ModelState.Clear();
                ViewBag.Message = citizensInfo.firstName + " " + citizensInfo.lastName +
                                  " blev registreret i databasen!";


            }

        

                    //insert data to googleinformation database
                    using (MyDbContext db2 = new MyDbContext())
                    {
                        GoogleMapsInformation googleMaps = new GoogleMapsInformation() { citizensRefId = citizensInfo.citizensID, Latitude = latitude, Longtitude = longtitude };

                        db2.GoogleMapsInformations.Add(googleMaps);

                        db2.SaveChanges();


                    }
                    ModelState.Clear();


            return View();

        }


      

        public ActionResult CreateSchedule()
        {

            Schedule model = new Schedule();
 


          MyDbContext db = new MyDbContext();


         //databaseFullName joins firstName and lastName to make fullName
         var databaseFullName = db.FullCitizensInfos
              .Select(s => new SelectListItem
             {
                  //value and text are the attributes of SelectListItem
                   //our value is ID, text is what makes up fullname
                   Value = s.citizensID.ToString(),
                  Text = s.firstName + " " + s.lastName
              });
            
         //databaseFullName is the var above, the Value and Text are from what we specificed in the definition of databaseFullName
              
this.ViewData["Citizens"] = new SelectList(databaseFullName, "Value", "Text");
                
              
         //creates a fullname for the dropdown for the UserAccounts as well
          var usersFullName = db.Useraccount
             .Select(s => new SelectListItem
              {
                 Value = s.UserID.ToString(),
                  Text = s.FirstName + " " + s.LastName
              });

          this.ViewData["Users"] = new SelectList(usersFullName, "Value", "Text");

            
            return View(model);
        }

     

        [HttpPost]
        public ActionResult CreateSchedule(Schedule schedule)
        {

        

            //checks if the form is filled in correctly
            if (ModelState.IsValid)
            {
                using (MyDbContext db = new MyDbContext())
                {

                    string citizensValue = Request.Form["Citizens"].ToString();
                    string usersValie = Request.Form["Users"].ToString();

                    System.Diagnostics.Debug.WriteLine(citizensValue);
                    System.Diagnostics.Debug.WriteLine(usersValie);

                    int convertedCit = Int32.Parse(citizensValue);
                    int convertedUsersVal = Int32.Parse(usersValie);

                    System.Diagnostics.Debug.WriteLine(convertedCit);
                    System.Diagnostics.Debug.WriteLine(convertedUsersVal);

                    schedule.citizensRefId = convertedCit;
                    schedule.userAccountRef = convertedUsersVal;

                    string dateAsString = Request.Form["StartDate"].ToString();

                    //parse datetime back to DateTime to fit database formalia.
                    DateTime dateTime = DateTime.Parse(dateAsString);
                    schedule.DateForVisiting = dateTime;



                    db.Schedules.Add(schedule);

                    db.SaveChanges();


                }

                //hackish way to solve a problem I was sitting with forever..
                return RedirectToAction("CreateSchedule", "Admin");
            


            }

            return View();

        }



        [HttpGet]  
        public ActionResult GetLatLong(double lng, double lat)
      {


          latitude = lat;
          longtitude = lng;
          Debug.WriteLine("latitude: " + latitude + " longtitude: " + longtitude);
            return Json("lng: " + lng + " lat: " + lat, JsonRequestBehavior.AllowGet);
        }


    }
}