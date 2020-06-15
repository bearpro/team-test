using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using team_test.Models;
using team_test.Services;
using team_test.ViewModels;

namespace team_test.Controllers
{
    public class TestController : Controller
    {
        private readonly TestService tests;
        private readonly QuestionRouterService router;

        public TestController(TestService questions, QuestionRouterService router)
        {
            this.tests = questions;
            this.router = router;
        }

        public IActionResult Index()
        {
            var model = new ViewModels.Test.Index
            {
                Tests = tests.GetAll(),
                RunningTestGuid = router.RunningTestGuid
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(string name)
        {
            await tests.Add(new Test { Name = name });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SetRunning(Guid guid)
        {
            router.RunningTestGuid = guid;
            return RedirectToAction("Index");
        }

        public IActionResult Questions(Guid guid)
        {
            var model = tests.Get(guid);
            return View(model);
        }
    }
}
