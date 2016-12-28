using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VolunteerTrack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InputActivity()
        {
            ViewBag.Message = "Enter your activity information here.";

            return View();
        }

        public ActionResult MyActivities()
        {
            ViewBag.Message = "Your Activities";
            return View();
        }
        public ActionResult Activities()
        {
            ViewBag.Message = "Your Activitives List";

            return View();
        }
        public ActionResult UpdateActivity()
        {
            return View("UpdateView");
        }
    }
}