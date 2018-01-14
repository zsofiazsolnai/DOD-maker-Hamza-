using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DOD_Maker_Hamza.Models;

namespace DOD_Maker_Hamza.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (DODdbContext db = new DODdbContext())
            {
                return View(db.User.ToList());
            }
        }

        public ActionResult Register()
        {
            ViewBag.IsReg = true;
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                using(DODdbContext db = new DODdbContext())
                {
                    db.User.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.FirstName + " " + user.LastName + " successfully registered :)";
                TempData["shortMessage"] = user.FirstName + " " + user.LastName + " successfully registered :)";
                return RedirectToAction("Login");
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            if(TempData["shortMessage"] != null)
                ViewBag.Message = TempData["shortMessage"].ToString();
            //ViewBag.IsLogin = true;
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using(DODdbContext db = new DODdbContext())
            {
                var usr = db.User.Where(u => u.EmailID == user.EmailID && u.Password == user.Password).FirstOrDefault();
                if(usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["FirstName"] = usr.FirstName.ToString();
                    ViewBag.IsLogin = true;
                    return RedirectToAction("DoDList", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email Id or Password is wrong.");
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserID"] != null)
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