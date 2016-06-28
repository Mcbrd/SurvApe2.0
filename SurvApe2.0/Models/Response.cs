using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurvApe2._0.Models
{
    public class Response
    {
        public int Id { get; set; }

        public int SurveyId { get; set; }

        public Survey Survey { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public string Value { get; set; }

    }
}