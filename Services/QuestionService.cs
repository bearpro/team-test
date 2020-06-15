using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task SetAnswer(Guid questionGuid, List<Guid> answersGuid)
        {
            var answers = db.Questions
                .Include(x => x.Answers)
                .Single(x => x.Guid == questionGuid)
                .Answers;
            foreach (var answer in answers)
            {
                if (answersGuid.Contains(answer.Guid))
                {
                    answer.IsRight = true;
                }
                else
                {
                    answer.IsRight = false;
                }
            }
            await db.SaveChangesAsync();
        }
    }
}