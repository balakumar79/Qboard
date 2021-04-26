using Qboard.Entities;
using Qboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qboard.Controllers
{
    public class HomeController : Controller
    {
        //BoardDbContext db = new BoardDbContext();
        QAContext db = new QAContext();

        public ActionResult Index()
        {
            var model = db.Questions.Select(o=>new QuestionViewModel
            {
                ExamId = o.ExamId,
                Exams = db.Exams.Where(l => l.Id == o.ExamId).ToList(),
                Created=o.Created
            }).ToList();
            return View(model);
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