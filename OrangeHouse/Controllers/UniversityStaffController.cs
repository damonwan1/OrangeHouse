using OrangeHouse.DAO;
using OrangeHouse.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace OrangeHouse.Controllers
{
    public class UniversityStaffController : Controller
    {

        private AdvertisementDAO advertisementDAO;
        private ApplicationDbContext db;

        public UniversityStaffController(ApplicationDbContext applicationDbContext, AdvertisementDAO advDAO)
        {
            db = applicationDbContext;
            advertisementDAO = advDAO;
        }

        // show the advertisements which are unprocessed
        public ActionResult Index()
        {
            if (HttpContext.Session["ID"] != null && !HttpContext.Session["ID"].ToString().Equals(""))
            {
              //  UniversityStaff staff =db.UniversityStaffs.Find((int)HttpContext.Session["staffID"]);
              
                return View("index", advertisementDAO.GetAdvsUnprocessed());
            }
            else {
                TempData["Message"] = "please login in again!";
                return RedirectToAction("Login","Login");
            }
            // List<Advertisement> advertisements=advertisementDAO.GetAdvsUnprocessed();
            // return View("Index",advertisements);
        }

        public ActionResult Getsession() {
            return View("index");
        }


        ////approve the advertisement by detail
        //public ActionResult PassByDetail(Advertisement advertisement) {
        //    if (advertisement != null)
        //    {
        //        //?? need find again or other method to update？？？？？
        //        advertisement = db.Advertisements.Find(advertisement.ID);
        //        advertisement.Pass = 1;
        //        db.Advertisements.Add(advertisement);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //approve the advertisement by main page
        public ActionResult Pass(string id) {
            if(id !=null && !id.Equals("")){
                Advertisement advertisement=db.Advertisements.Find(int.Parse(id));
                advertisement.Pass = 1;
                db.Entry(advertisement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
             }
            return View();
        }

        //fail the advertisement by main page
        public ActionResult Fail(string id ,string refuseReason)
        {
            if (id != null && !id.Equals(""))
            {
                Advertisement advertisement = db.Advertisements.Find(int.Parse(id));
                advertisement.Pass = 2;
                if (refuseReason != null && !refuseReason.Equals(""))
                {
                    advertisement.RefuseReason = refuseReason;
                }
                db.Entry(advertisement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // GET: UniversityStaff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversityStaff/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password")] ApplicationUser universityStaff)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(universityStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(universityStaff);
        }

        // GET: UniversityStaff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser universityStaff = db.Users.Find(id);
            if (universityStaff == null)
            {
                return HttpNotFound();
            }
            return View(universityStaff);
        }

        // POST: UniversityStaff/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password,Birthday")] ApplicationUser universityStaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universityStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(universityStaff);
        }

        // GET: UniversityStaff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser universityStaff = db.Users.Find(id);
            if (universityStaff == null)
            {
                return HttpNotFound();
            }
            return View(universityStaff);
        }

        // POST: UniversityStaff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicationUser universityStaff = db.Users.Find(id);
            db.Users.Remove(universityStaff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
