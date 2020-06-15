using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using team_test.Models;

namespace team_test.ViewModels.Test
{
    public class Index
    {
        public List<Models.Test> Tests { get; set; }
        public Guid RunningTestGuid { get; set; }
    }
}