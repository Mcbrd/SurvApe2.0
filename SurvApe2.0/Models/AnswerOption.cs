using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurvApe2._0.Models
{
    public class AnswerOption
    {
        public int Id { get; set; }

        public virtual int QuestionId { get; set; }

        public string AnswerText { get; set; }
    }
}