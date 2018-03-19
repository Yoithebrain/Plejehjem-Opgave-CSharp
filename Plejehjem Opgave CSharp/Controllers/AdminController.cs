using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plejehjem_Opgave_CSharp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult CreateCitizens()
        {
            return View();
        }
    }
}