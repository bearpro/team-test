using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace team_test.Models
{
    public enum QuestionType { SingleAnswer, ManyAnswers }

    public class Question
    {
        [Key]
        public Guid Guid { get; set; }
        public Guid TestGuid { get; set; }
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
