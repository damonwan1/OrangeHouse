using Microsoft.AspNet.Identity;
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
        private ApplicationDbContext db;

        public HomeController(ApplicationDbContext applicationDbContext) {
            db = applicationDbContext;
        }

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
                if (HttpContext.Session["ID"] == null || HttpContext.Session["ID"].ToString().Equals(""))
                {
                    HttpContext.Session.Add("ID", user.Id);
                }


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