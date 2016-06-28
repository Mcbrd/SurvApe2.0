using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurvApe2._0.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public int ResponseId { get; set; }

        public Response Response { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public string Value { get; set; }
    }
}