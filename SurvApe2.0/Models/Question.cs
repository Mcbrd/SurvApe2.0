﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurvApe2._0.Models
{
    public class Question
    {
        public int Id { get; set; }

        public int SurveyId { get; set; }

        public string QuestionText { get; set; }

        public List<Answer> Answers { get; set; }
    }
}