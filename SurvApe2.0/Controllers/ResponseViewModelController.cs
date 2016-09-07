using SurvApe2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurvApe2._0.Controllers
{
    public class ResponseViewModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //private readonly ApplicationDbContext db;
        //public ResponseViewModelController()
        //{

        //}
        //// GET: ResponseVie
        //public ResponseViewModelController(ApplicationDbContext _db)
        //{
        //    db = _db;
        //}
        //public ActionResult Index()
        //{
        //    return View(db.Surveys.ToList());
        //}
        // GET: ResponseViewModel
        public ActionResult Index(int? id)
        {
            List<QuestionViewModel> questionsVM = new List<QuestionViewModel>();
            Survey survey = db.Surveys.Find(id);
            var responseQuery = from r in db.Responses
                                where r.SurveyId == id
                                select r;
            List<Response> Responses = responseQuery.ToList();

            var questionQuery = from q in db.Questions
                                where q.SurveyId == id
                                select q;
            List<Question> questions = questionQuery.ToList();
             

            var vm = new ResponseViewModel
            {

                Survey = survey,
                Questions = questionsVM
            };

            foreach (Question item in questions)
            {

                QuestionViewModel qvm = new QuestionViewModel();
                qvm.QuestionText = item.QuestionText;

                questionsVM.Add(qvm);
            }

            return View(vm);
        }
    }
}