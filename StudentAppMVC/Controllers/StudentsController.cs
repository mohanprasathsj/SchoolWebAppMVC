using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentAppMVC.Models;
using StudentAppMVC.View_Models;

namespace StudentAppMVC.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            var viewModel = new StudentViewModel();
            var classes = db.SchoolClasses.ToList();
            viewModel.Classes = db.SchoolClasses.Select(x => new SelectListItem { Value=x.SchoolClassId.ToString(), Text=x.Name }).ToList<SelectListItem>();
            return View(viewModel);
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Email,ParentEmail,PhoneNumber, StudentClassId")] StudentViewModel studentVM)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();
                student.StudentId = Guid.NewGuid();
                student.Name = studentVM.Name;
                student.Email = studentVM.Email;
                student.ParentEmail = studentVM.ParentEmail;
                student.PhoneNumber = studentVM.PhoneNumber;
                student.StudentClassId = studentVM.StudentClassId;
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentVM);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            StudentViewModel studentVM = new StudentViewModel();
            studentVM.Name = student.Name;
            studentVM.Email = student.Email;
            studentVM.ParentEmail = student.ParentEmail;
            studentVM.PhoneNumber = student.PhoneNumber;
            studentVM.StudentId = student.StudentId;
            studentVM.StudentClassId = student.StudentClassId;
            studentVM.Classes = db.SchoolClasses.Select(x => new SelectListItem { Text = x.Name, Value = x.SchoolClassId.ToString() });
            return View(studentVM);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Email,ParentEmail,PhoneNumber,StudentClassId")] StudentViewModel studentVM)
        {
            if (ModelState.IsValid)
            {
                var student = db.Students.Find(studentVM.StudentId);
                student.Name = studentVM.Name;
                student.Email = studentVM.Email;
                student.ParentEmail = studentVM.ParentEmail;
                student.PhoneNumber = studentVM.PhoneNumber;
                student.StudentClassId = studentVM.StudentClassId;
                
                db.Entry(studentVM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentVM);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
