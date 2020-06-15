using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using team_test.Models;
using team_test.Services;

namespace team_test.Controllers
{
    public class QuestionController : Controller
    {
        private readonly QuestionService questions;

        public QuestionController(QuestionService questions)
        {
            this.questions = questions;
        }

        // public IActionResult Index()
        // {
        //     //var model = questions.GetAll();
        //     //return View(model);
        // }

        [HttpPost]
        public async Task<IActionResult> Add(Question question)
        {
            await questions.Add(question);
            return View();
        }
    }
}
