using OrangeHouse.DAO;
using OrangeHouse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OrangeHouse.Controllers
{
    public class StudentController : Controller
    {
        private AdvertisementDAO advertisementDAO;
        private ApplicationDbContext db;

        public StudentController(ApplicationDbContext applicationDbContext, AdvertisementDAO advDAO) {
            db = applicationDbContext;
            advertisementDAO = advDAO;
        }

        // GET: Student
        public ActionResult Index()
            {
                if (HttpContext.Session["ID"] != null && !HttpContext.Session["ID"].ToString().Equals(""))
                {
                    // db.Students.Find((int)HttpContext.Session["ID"]);

                    return View("index", advertisementDAO.GetAdvsPass());
                }
                else
                {
                    TempData["Message"] = "please login in again ,session is out of time!";
                    return RedirectToAction("Login", "Login");
                }
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
            return View("Details", advertisement);
        }


        //// GET: Student/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Student/Create
        //// 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        //// 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Username,Password,Birthday")] Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Students.Add(student);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(student);
        //}

        //// GET: Student/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.Students.Find(id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        //// POST: Student/Edit/5
        //// 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        //// 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Username,Password,Birthday")] Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(student).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(student);
        //}

        //// GET: Student/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.Students.Find(id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        //// POST: Student/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Student student = db.Students.Find(id);
        //    db.Students.Remove(student);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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