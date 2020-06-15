using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using team_test.Models;


namespace team_test.Services
{
    public class QuestionService
    {
        private readonly QuestionContext db;
        public QuestionService(QuestionContext db)
        {
            this.db = db;
        }

        public async Task Add(Question question)
        {
            await db.Questions.AddAsync(question);
            await db.SaveChangesAsync();
        }
    }
}