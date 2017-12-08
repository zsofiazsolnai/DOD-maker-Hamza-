﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOD_Maker_Hamza.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Help()
        {
            ViewBag.Message = "Your help guide.";

            return View();
        }

        public ActionResult DoDList()
        {
            ViewBag.Example = new List<string> { "All (subtasks|TODO items) are done",
                                                 "đTests are passing ",
                                                 "*All code has unit tests",
                                                 "Tasks describing identified technical debt are added ",
                                                 "ä Code| scripts committed to the repository",
                                                 "Code has been reviewed by łdev.  and all suggestions  has been introduced.",
                                                 "Basic DoD <>",
                                                 "Basic DoD []",
                                                 "Basic DoD #8",
                                                 "Basic DoD #9"};
            return View();
        }
    }
}