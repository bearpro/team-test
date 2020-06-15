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
    public class TestController : Controller
    {
        private readonly TestService tests;

        public TestController(TestService questions)
        {
            this.tests = questions;
        }

        public IActionResult Index()
        {
            var model = tests.GetAll();
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

        public IActionResult Questions(Guid guid)
        {
            var model = tests.Get(guid);
            return View(model);
        }
    }
}
