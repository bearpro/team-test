using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using team_test.Models;
using team_test.ViewModels.Api.Question;
using team_test.Services;


namespace team_test.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionRouterService router;
        private readonly QuestionService questions;
        private readonly TestService tests;
        public QuestionController(QuestionService questions, QuestionRouterService router, TestService tests)
        {
            this.router = router;
            this.questions = questions;
            this.tests = tests;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostNew payload)
        {
            var question = new Models.Question
            {
                Answers = payload.Answ.Select(text => new Models.Answer { Text = text }).ToList(),
                QuestionType = payload.Type switch
                {
                    "SingleAnswer" => Models.QuestionType.SingleAnswer,
                    "ManyAnswers" => Models.QuestionType.ManyAnswers,
                    string other => throw new ArgumentException($"Не поддерживаемый тип вопроса {other}")
                },
                TestGuid = payload.TestGuid ?? router.RunningTestGuid,
                Text = payload.Question
            };
            await questions.Add(question);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Answer(ViewModels.Api.Question.Answer payload)
        {
            await questions.SetAnswer(payload.QuestionGuid, payload.AnswersGuid);
            return Ok();
        }
    
        public List<Question> All(Guid? questionGuid)
        {
            var guid = questionGuid ?? router.RunningTestGuid;
            var question = tests.Get(guid).Questions;
            return question;
        }

        public List<Question> NotAnswered(Guid? questionGuid)
        {
            var guid = questionGuid ?? router.RunningTestGuid;
            var question = tests.Get(guid).Questions;
            return question;
        }
    }
}