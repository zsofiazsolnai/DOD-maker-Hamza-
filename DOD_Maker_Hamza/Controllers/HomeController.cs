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
            //List<MyDODs> testList = new List<MyDODs>();
            //MyDODs dod1 = new MyDODs();
            //dod1.MyDOD = "dod1";
            //dod1.OwnerName = "Hamza";
            //testList.Add(dod1);
            //dod1 = new MyDODs();

            //dod1.MyDOD = "dod2";
            //dod1.OwnerName = "Hamza";
            //testList.Add(dod1);
            //dod1 = new MyDODs();

            //dod1.MyDOD = "dod3";
            //dod1.OwnerName = "Hamza";
            //testList.Add(dod1);

            //saveMyDODs(testList);

            ViewBag.Example = new List<string> { "All (subtasks|TODO items) are done",
                                                 "đTests/type are passing ",
                                                 "*All code/section has unit tests",
                                                 "Tasks describing identified technical debt are added ",
                                                 "ä Code| scripts checked-in|committed to the repository",
                                                 "Code has been reviewed by łdev.  and all suggestions  has been introduced.",
                                                 "Basic DoD <>",
                                                 "Basic DoD []",
                                                 "Basic DoD #8",
                                                 "Basic DoD #9"};
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
            //   foreach (DODTemplates dos in dodList) { Console.Write(dos.DODTemplate); } ;
            //   getType(1);
            return dodList;

        }

        public void getType(int TemplateID)
        {
            DODdbContext db = new DODdbContext();
            List<DOD_Option> templateType = db.DOD_Option.Where(type => type.DODTemplateID == TemplateID).ToList();

            // foreach (DOD_Option dos in templateType) { Console.Write(dos.Option_Text); }
        }

        public void saveMyDODs (List<MyDODs> mydods)
        {
            DODdbContext db = new DODdbContext();
            db.MyDODs.AddRange(mydods);
            db.SaveChanges();

        }
    }

}