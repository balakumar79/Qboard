using Microsoft.Ajax.Utilities;
using Qboard.Entities;
using Qboard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Qboard.Controllers
{
    public class QuestionController : Controller
    {
        QAContext db = new QAContext();

        // GET: Question
        public ActionResult Index()
        {
            return View(db.Questions.Select(p => new QuestionViewModel
            {
                Answers = db.Answers.Where(o => o.QuestionId == p.Id).ToList(),
                Modified = p.Modified,
                Skills = db.Skills.ToList(),
                ContempararyLevels = db.ContempararyLevels.ToList(),
                ExamId = p.ExamId,
                Created = p.Created,
                Exams = db.Exams.ToList(),
                Id = p.Id,
                IsActove = p.IsActove,
                Question = p.Name
            }).ToList());
        }


        // GET: Question/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            var model =
                from q in db.Questions
                join c in db.Exams on q.ExamId equals c.Id
                where q.Id == id
                select new QuestionViewModel()
                {
                    Id = q.Id,
                    Question = q.Name,
                    Created = q.Created,
                    IsActove = q.IsActove,
                    ExamId = q.ExamId,
                    Exams=db.Exams.ToList(),
                    ContempararyLevels=db.ContempararyLevels.ToList(),
                    Skills=db.Skills.ToList(),
                    Modified=q.Modified,
                    Answers = db.Answers.Where(p => p.QuestionId == q.Id).ToList(),
                    
                };
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model.FirstOrDefault());
        }

        [HttpPost]
        public bool Details(QuestionViewModel questionViewModel)
        {
            if (ModelState.IsValid)
            {
                var qustionDB = db.Questions.Where(l=>l.Id==questionViewModel.Id).FirstOrDefault();
                qustionDB.Name = questionViewModel.Question;
                qustionDB.ExamId = questionViewModel.ExamId;
                qustionDB.Modified = DateTime.Now;
                db.Questions.Update(qustionDB);
                db.SaveChanges();
                db.Answers.RemoveRange(db.Answers.Where(p=>p.QuestionId==questionViewModel.Id));
                questionViewModel.Answers.ForEach(p => p.QuestionId = qustionDB.Id);
                db.Answers.AddRange(questionViewModel.Answers);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            var model = new QuestionViewModel();
            model.Exams = db.Exams.ToList();
            model.ContempararyLevels = db.ContempararyLevels.ToList();
            model.Skills = db.Skills.ToList();
            return View(model);
        }

        [HttpPost]
        public bool Create(QuestionViewModel question)
        {
            
            if (ModelState.IsValid)
            {
                var qustionDB = new Questions();
                qustionDB.Name = question.Question;
                qustionDB.ExamId = question.ExamId;
                qustionDB.Created = DateTime.Now;
                qustionDB.Modified = DateTime.Now;
                db.Questions.Add(qustionDB);
                db.SaveChanges();
                question.Answers.ForEach(p => p.QuestionId = qustionDB.Id);
                db.Answers.AddRange(question.Answers);
                db.SaveChanges();
                return true;
            }
            //question.Exams = db.Exams.ToList();
            //question.Skills= db.Skills.ToList();
            return false;
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var question = db.Questions.Where(p => p.Id == id).Select(k => new QuestionViewModel
            {
                Answers = db.Answers.Where(l => l.QuestionId == k.Id).ToList(),
                Skills = db.Skills.ToList(),
                ContempararyLevels = db.ContempararyLevels.ToList(),
                Created = k.Created,
                ExamId = k.ExamId,
                Id = k.Id,
                Exams = db.Exams.ToList(),
                IsActove = k.IsActove,
                Modified = k.Modified,
                Question = k.Name
            }).FirstOrDefault();
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Questions question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Questions question = db.Questions.Find(id);
            db.Questions.Remove(question);
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
