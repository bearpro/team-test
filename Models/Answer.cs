using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace team_test.Models
{
    public class Answer
    {
        [Key]
        public Guid Guid { get; set; }
        public Guid QuestionGuid { get; set; }
        public string Text { get; set; }
        public bool IsRight { get; set; }
    }
}
