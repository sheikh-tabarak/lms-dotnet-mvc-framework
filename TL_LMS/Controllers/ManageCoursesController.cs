using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TL_LMS.Models;

namespace TL_LMS.Controllers
{
    public class ManageCoursesController : Controller
    {
        private LMS2Entities2 db = new LMS2Entities2();
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Teacher);
            return View(courses.ToList());
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }
        public ActionResult Create()
        {
            ViewBag.course_instructor = new SelectList(db.Teachers, "instructor_id", "instructor_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "course_id,course_title,course_instructor,course_CH")]Cours cours)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Courses.Add(cours);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }
            catch (Exception)
            {

            }
           ViewBag.course_instructor = new SelectList(db.Teachers, "instructor_id", "instructor_name", cours.course_instructor);
            return View(cours);
        }

        // GET: ManageCourses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            ViewBag.course_instructor = new SelectList(db.Teachers, "instructor_id", "instructor_name", cours.course_instructor);
            return View(cours);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "course_id,course_title,course_instructor,course_CH")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cours).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.course_instructor = new SelectList(db.Teachers, "instructor_id", "instructor_name", cours.course_instructor);
            return View(cours);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cours cours = db.Courses.Find(id);
            db.Courses.Remove(cours);
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
