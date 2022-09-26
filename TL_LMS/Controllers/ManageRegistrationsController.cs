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
    public class ManageRegistrationsController : Controller
    {
        private LMS2Entities2 db = new LMS2Entities2();
        public ActionResult Index()


        {
            var registrations = db.Registrations.Include(r => r.Cours).Include(r => r.Student).Include(r => r.Teacher);


            ViewBag.students = db.Students.Count();
            ViewBag.teachers = db.Teachers.Count();

            ViewBag.courses = db.Courses.Count();
            ViewBag.registrations = db.Registrations.Count();


            return View(registrations.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }
        public ActionResult Create()
        {
            ViewBag.course_id = new SelectList(db.Courses, "course_id", "course_title");
            ViewBag.student_id = new SelectList(db.Students, "student_reg_no", "student_name");
            ViewBag.teacher_id = new SelectList(db.Teachers, "instructor_id", "instructor_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reg_id,student_id,teacher_id,course_id,reg_date,reg_fee")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.course_id = new SelectList(db.Courses, "course_id", "course_title", registration.course_id);
            ViewBag.student_id = new SelectList(db.Students, "student_reg_no", "student_name", registration.student_id);
            ViewBag.teacher_id = new SelectList(db.Teachers, "instructor_id", "instructor_name", registration.teacher_id);
            return View(registration);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.course_id = new SelectList(db.Courses, "course_id", "course_title", registration.course_id);
            ViewBag.student_id = new SelectList(db.Students, "student_reg_no", "student_name", registration.student_id);
            ViewBag.teacher_id = new SelectList(db.Teachers, "instructor_id", "instructor_name", registration.teacher_id);
            return View(registration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reg_id,student_id,teacher_id,course_id,reg_date,reg_fee")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.course_id = new SelectList(db.Courses, "course_id", "course_title", registration.course_id);
            ViewBag.student_id = new SelectList(db.Students, "student_reg_no", "student_name", registration.student_id);
            ViewBag.teacher_id = new SelectList(db.Teachers, "instructor_id", "instructor_name", registration.teacher_id);
            return View(registration);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Registration registration = db.Registrations.Find(id);
            db.Registrations.Remove(registration);
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
