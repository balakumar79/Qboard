using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Qboard.Entities;
using Qboard.Models;

namespace Qboard.Controllers
{
    public class ExamController : Controller
    {
        private QAContext db = new QAContext();

        // GET: Exam
        public ActionResult Index()
        {
            return View(db.Exams.ToList());
        }

        // GET: Exam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var  examViewModel = db.Exams.Find(id);
            if (examViewModel == null)
            {
                return HttpNotFound();
            }
            return View(examViewModel);
        }

        // GET: Exam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExamName,Skill,ContempararyLevel,Created,Modified,IsActive")] ExamViewModel examViewModel)
        {
            if (ModelState.IsValid)
            {
                var exam = new Exams();
                exam.ExamName = examViewModel.ExamName;
                exam.ContempararyLevel = examViewModel.ContempararyLevel;
                exam.Skill = examViewModel.Skill;
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examViewModel);
        }

        // GET: Exam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var examViewModel = db.Exams.Select(p=>new ExamViewModel
            {
                Id = p.Id,
                ContempararyLevel = p.ContempararyLevel,
                Skill = p.Skill,
                ExamName = p.ExamName,
                IsActive = p.IsActive
            }).Where(p=>p.Id==id).FirstOrDefault();
            if (examViewModel == null)
            {
                return HttpNotFound();
            }
            return View(examViewModel);
        }

        // POST: Exam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExamName,Skill,ContempararyLevel,Created,Modified,IsActive")] ExamViewModel examViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examViewModel).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examViewModel);
        }

        // GET: Exam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var examViewModel = db.Exams.Find(id);
            if (examViewModel == null)
            {
                return HttpNotFound();
            }
            return View(examViewModel);
        }

        // POST: Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var examViewModel = db.Exams.Find(id);
            db.Exams.Remove(examViewModel);
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
