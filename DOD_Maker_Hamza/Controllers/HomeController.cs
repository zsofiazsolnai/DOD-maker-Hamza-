using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOD_Maker_Hamza.Models;

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
            //ViewBag.Example = new List<string> { "All (subtasks|TODO items) are done",
            //                                     "đTests/type are passing ",
            //                                     "*All code/section has unit tests",
            //                                     "Tasks describing identified technical debt are added ",
            //                                     "ä Code| scripts checked-in|committed to the repository",
            //                                     "Code has been reviewed by łdev.  and all suggestions  has been introduced.",
            //                                     "Basic DoD <>",
            //                                     "Basic DoD []",
            //                                     "Basic DoD #8",
            //                                     "Basic DoD #9"};
            ViewBag.Example = getAllDODTemplates();
            return View();
        }
       
        /// <summary>
        /// This method is getting all the DOD templates from the database returning a list of DODTemplates
        /// </summary>
        /// <returns></returns>
        public List<DODTemplates> getAllDODTemplates()
        {
            DODdbContext db = new DODdbContext();
            List<DODTemplates> dodList = db.DODTemplate.ToList();
            return dodList;

        }

        public void getType(int TemplateID)
        {
            DODdbContext db = new DODdbContext();
            List<DOD_Option> templateType = db.DOD_Option.Where(type => type.DODTemplateID == TemplateID).ToList();
        }

        public void saveMyDODs(string[] dodList, string name)
        {
            DODdbContext db = new DODdbContext();
            List<MyDODs> myDOD = new List<MyDODs>();
            foreach (string dod in dodList)
            {
                myDOD.Add(new MyDODs(dod, name));
            }
            db.MyDODs.AddRange(myDOD);
            db.SaveChanges();

        }
    }

}