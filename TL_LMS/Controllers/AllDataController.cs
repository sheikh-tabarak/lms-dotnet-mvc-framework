using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TL_LMS.Models;

namespace TL_LMS.Controllers
{
    public class AllDataController : Controller
    {
        AllDataContext db = new AllDataContext();
        // GET: AllData
        public ActionResult Index()
        {
            List<ManageStudentsController> students = new List<ManageStudentsController>();
            List<ManageTeachersController> teachers = new List<ManageTeachersController>();
            List<ManageCoursesController> courses = new List<ManageCoursesController>();
            List<ManageRegistrationsController> registrations = new List<ManageRegistrationsController>();
           
            //var s_count = db.registrations.Count().ToString();

            var tables = new AllData
            {
                students = db.students.ToList(),
                teachers = db.teachers.ToList(),
                courses = db.courses.ToList(),
                registrations = db.registrations.ToList(),
           //     coursescount = s_count;

            };

           // ViewBag.test = "Test";
            TempData["totalstudent"] = db.students.Count();
            TempData["totalteachers"] = db.teachers.Count();
            TempData["totalcourses"] = db.courses.Count();
            TempData["totalregistrations"] = db.registrations.Count();

          //  return new RedirectResult(@"~\Home\Index");
            return View(tables);
        }


        public ActionResult Count()

        {
           // var students
                
                ViewBag.totalstudent = db.students.Count();

            return View();

        }




        // GET: AllData/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AllData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllData/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AllData/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AllData/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AllData/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AllData/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
