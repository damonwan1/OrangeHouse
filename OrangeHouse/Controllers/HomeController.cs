using Microsoft.AspNet.Identity.EntityFramework;
using OrangeHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrangeHouse.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            if (HttpContext.Session["ID"] != null && !HttpContext.Session["ID"].ToString().Equals(""))
            {
                ApplicationUser user = db.Users.Find(HttpContext.Session["ID"]);

                if (user.RoleType.Equals("Student"))
                {
                    return RedirectToAction("Index", "Student");
                }
                else if (user.RoleType.Equals("Landlord"))
                {
                    return RedirectToAction("Index", "Landlord");
                }
                else
                {
                    return RedirectToAction("Index", "UniversityStaff");
                }

            }
            else {
                return View();
            }
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

    }
}