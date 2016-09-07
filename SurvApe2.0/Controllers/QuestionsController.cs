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
    public class QuestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Questions
        public ActionResult Index()
        {
            return View(db.Questions.ToList());
        }


        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()

        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SurveyId,QuestionText,Type,AnswerOptions,Answers")] Question question, Survey survey)
        {
            survey = (Survey)TempData["survey"];

            if (ModelState.IsValid)
            {
                question.SurveyId = survey.Id;

                db.Questions.Add(question);
                //foreach (AnswerOption ao in question.AnswerOptions)
                //{
                //    db.AnswerOptions.Add(ao);
                //}
                //foreach (Answer a in question.Answers)
                //{
                //    db.Answers.Add(a); //null
                //}
                db.SaveChanges();
                return RedirectToAction("Create");
                //return RedirectToAction("AnswerOptions", new { id = question.Id});
            }

            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult AnswerOptions(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnswerOptions([Bind(Include = "Id,SurveyId,QuestionText,Type,AnswerOption")] Question question, Survey survey)
        {
            survey = (Survey)TempData["survey"];

            if (ModelState.IsValid)
            {
                question.SurveyId = survey.Id;
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SurveyId,QuestionText,AnswerOption")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost]

        //public ActionResult Submit(List<AnswerOption> ao)
        //{
        //    Response response = new Response();

        //    foreach (AnswerOption item in ao)
        //    {
        //        response.Value = item.AnswerText;
        //        response.SurveyId = item.QuestionId;
        //        db.Responses.Add(response);
        //        db.SaveChanges();

        //    }
        //    return View();
        //}


        [HttpPost]

        public ActionResult Submit(List<Question> model, List<AnswerOption> ao)
        {

            //if (model == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Answer answer = new Answer();
            //Response response = new Response();
            //foreach (AnswerOption item in model)//null for answer option - different submit button for q and a?
            //{

            //    db.AnswerOptions.Add(item);
            //    db.SaveChanges();

            //}
            //return View();

            Answer answer = new Answer();
            Response response = new Response(); //might need these 2^
            if(model != null)
            {
                foreach (Question item in model)//null for answer option/values - different parameters? form group in view?
                {

                    response.Value = item.Value;
                    response.SurveyId = item.SurveyId;
                    db.Responses.Add(response);
                    db.SaveChanges();

                }
            }

            if (ao != null)
            {
                foreach (AnswerOption item in ao)
                {
                    response.Value = item.AnswerText;
                    response.SurveyId = item.QuestionId;
                    db.Responses.Add(response);
                    db.SaveChanges();

                }
            }

               
            return View();
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
