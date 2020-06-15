using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using team_test.Models;


namespace team_test.Services
{
    public class TestService
    {
        private readonly QuestionContext db;
        public TestService(QuestionContext db)
        {
            this.db = db;
        }

        public List<Test> GetAll()
        {
            return db.Tests.ToList();
        }

        public async Task Add(Test test)
        {
            await db.Tests.AddAsync(test);
            await db.SaveChangesAsync();
        }

        public Test Get(Guid guid)
        {
            var test =
                db.Tests
                    .Include(test => test.Questions)
                        .ThenInclude(question => question.Answers)
                    .Single(test => test.Guid == guid);
            return test;
        }
    }
}