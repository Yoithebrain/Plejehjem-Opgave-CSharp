using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plejehjem_Opgave_CSharp.Models;

namespace Plejehjem_Opgave_CSharp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        public ActionResult Index()
        {
            using (MyDbContext db = new MyDbContext())
            {
                return View(db.Useraccount.ToList());

            }

        }

        public ActionResult Register()
        {
            return View();
        }
       

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            //make validation
            if (ModelState.IsValid)
            {
                using (MyDbContext db = new MyDbContext())
                {
                    db.Useraccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered.";
            }
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            // use database to validate
            using (MyDbContext db = new MyDbContext())
            {
                var usr = db.Useraccount.Select(p => p).FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

               
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoggedIn","Account");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong. ");
                }
            }
               return View("LoggedIn");
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
    }
}