using System;
using Microsoft.EntityFrameworkCore;
using team_test.Models;

namespace team_test.Services
{
    public class QuestionContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public QuestionContext(DbContextOptions<QuestionContext> options) 
            : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}