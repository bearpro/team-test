using System;
using System.Collections.Generic;

namespace team_test.ViewModels.Api.Question
{
    public class PostNew
    {
        public Guid? TestGuid { get; set; }
        public List<string> Answ { get; set; }
        public string Type { get; set; }
        public string Question { get; set; }
    }

    public class Answer
    {
        public Guid QuestionGuid { get; set; }
        public List<Guid> AnswersGuid { get; set; }
    }
}