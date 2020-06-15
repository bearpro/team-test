using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace team_test.Models
{
    public class Test
    {
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
