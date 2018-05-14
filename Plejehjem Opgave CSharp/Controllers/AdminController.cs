using System;
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

            //wait 1500 ms.
            System.Threading.Timer timer = null;
            timer = new System.Threading.Timer((obj) =>
            {

                
                
                //insert data to googleinformation database
                using (MyDbContext db2 = new MyDbContext())
                {
                    GoogleMapsInformation googleMaps = new GoogleMapsInformation() { mapsRefId = citizensInfo.citizensID, Latitude = latitude, Longtitude = longtitude};

                    db2.GoogleMapsInformations.Add(googleMaps);

                    db2.SaveChanges();


                }
                ModelState.Clear();
          
            },
                null, 3000, System.Threading.Timeout.Infinite);

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