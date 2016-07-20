using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurvApe2._0.Models;

namespace SurvApe2._0.Controllers
{
    public class SurveysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Surveys
        public ActionResult Index()
        {
            return View(db.Surveys.ToList());
        }

        // GET: Surveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: Surveys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Survey survey)
        {
                        TempData["survey"] = survey;

            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Create", "Questions");
            }

            return View(survey);
        }

        // GET: Surveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AnswerQuestions(int? id)
        {
           //List<Question> questList = new List<Question>();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            var questionQuery = from q in db.Questions
                           where q.SurveyId == id
                           select q;
            List<Question> questList = questionQuery.ToList();
      

            if (questList == null)
            {
                return HttpNotFound();
            }
            return View(questList);
        }

        public ActionResult ViewResponses(int? id)
        {
            //List<Question> questList = new List<Question>();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            var responseQuery = from q in db.Responses
                                where q.SurveyId == id
                                select q;
            List<Response> responseList = responseQuery.ToList();


            if (responseList == null)
            {
                return HttpNotFound();
            }
            return View(responseList); // ^Workingish

            //List<QuestionViewModel> questionsVM = new List<QuestionViewModel>();
            //Survey survey = db.Surveys.Find(id);
            //var responseQuery = from r in db.Responses
            //                    where r.SurveyId == id
            //                    select r;
            //List<Response> Responses = responseQuery.ToList();

            //var questionQuery = from q in db.Questions
            //                    where q.SurveyId == id
            //                    select q;
            //List<Question> questions = questionQuery.ToList();


            //var vm = new ResponseViewModel
            //{
         
            //    Survey = survey,
            //    Questions = questionsVM
            //};

            //foreach(Question item in questions)
            //{

            //    QuestionViewModel qvm = new QuestionViewModel();
            //    qvm.QuestionText = item.QuestionText;

            //    questionsVM.Add(qvm);
            //        }

            //return View(vm);




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
