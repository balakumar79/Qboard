using Qboard.Entities;
using Qboard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Qboard.Controllers
{
    public class AnswerController : Controller
    {
        // GET: Answer
        private QAContext db = new QAContext();

        // GET: Answer
        public ActionResult Index([Bind(Prefix = "id")] int questionId)
        {
          
           var question= db.Questions.Where(q => q.Id == questionId);
            db.SaveChanges();

            if (question != null)
            {
                var model = db.Questions.Where(e=>e.Id==questionId).Select(o=>
                new QuestionViewModel
                {
                    Answers = db.Answers.Where(l => l.QuestionId == questionId).ToList(),
                    Id = o.Id,
                    IsActove = o.IsActove,
                    Question = o.Name
                }).FirstOrDefault();
                
                return View(model);
            }
            return HttpNotFound();
            //return View(db.Answers.ToList());
        }

        // GET: Answer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answers answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // GET: Answer/Create
        public ActionResult Create(int questionId, DateTime date/*, string body*/)
        {
            return View();
        }

        // POST: Answer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Body,QuestionId")] Answers answer)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Where(q => q.Id == answer.QuestionId).FirstOrDefault();
                db.Answers.Add(answer);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = answer.QuestionId });
                //    return View(answer);
            }

            return View(answer);
        }

        
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var answer = db.Answers.Where(l => l.Id ==id).Select(m => new AnswerViewModel
            {
                Answer = m.Name,
                Id = m.Id,
                IsActive = m.IsActive,
                IsCorrect = m.IsCorrect,
                QuestionId = m.QuestionId
            }).FirstOrDefault();
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

       
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(AnswerViewModel answerViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Answers.Where(m => m.Id == answerViewModel.Id).FirstOrDefault();
                entity.Name = answerViewModel.Answer;
                db.Answers.Update(entity);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = answerViewModel.QuestionId });
            }
            return View(answerViewModel);
        }

        // GET: Answer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answers answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Answers answer = db.Answers.Find(id);
            db.Answers.Remove(answer);
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
