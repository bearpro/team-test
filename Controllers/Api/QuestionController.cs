using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using team_test.ViewModels.Api.Question;
using team_test.Services;
using System.Threading.Tasks;

namespace team_test.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionRouterService router;
        private readonly QuestionService questions;
        public QuestionController(QuestionService questions, QuestionRouterService router)
        {
            this.router = router;
            this.questions = questions;
        }
        public async Task<IActionResult> Post(PostNew payload)
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
    }
}