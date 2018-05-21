using Plejehjem_Opgave_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plejehjem_Opgave_CSharp.Controllers
{
    public class WorkController : Controller
    {
        // GET: Work
        public ActionResult details_VP()
        {
            using (MyDbContext Mydb = new MyDbContext())
            {
                var othercontacts = (from c in Mydb.CitizensContacts
                                     join f in Mydb.FullCitizensInfos
                                     on c.citizensRefId equals f.citizensID
                                     select new MyContacts()
                                     {
                                         _jobtitle = c.JobTitle,
                                         _fullName = c.FirstName + c.LastName,
                                         _phonenumber = c.PhoneNumber,
                                         _otherInfo = c.otherInformation

                                     }).ToList<MyContacts>();
                return View(othercontacts);
            }
            
        }

        // GET: Work/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Work/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Work/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Work/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Work/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Work/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Work/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
