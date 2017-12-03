using System;
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
            ViewBag.Exists = new List<int>();
            ViewBag.Example = new List<string> { "Basic DoD (multiplechoice)", "Basic DoD <parameter>", "Basic DoD #3", "Basic DoD #4",
                                                "Basic  DoD #5 [option]","Basic DoD #6","Basic DoD #7","Basic DoD #8"};
            return View();
        }
    }
}