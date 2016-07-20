using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurvApe2._0.Models
{
    public class ResponseViewModel
    {
        public ResponseViewModel()
        { }
        public int Id { get; set; }
        public Survey Survey { get; set; }
        public List<QuestionViewModel> Questions { get; set; }


    }

    public class QuestionViewModel
    {
        public  QuestionViewModel()
        { }

        public string Title { get; set; }
        public string QuestionText { get; set; }
        public string Type { get; set; }
        public List<Response> Responses { get; set; }
        public List<Answer> Answers { get; set; }


    }
}