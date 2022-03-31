using Microsoft.AspNetCore.Mvc;
using MySQLBowling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLBowling.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlingRepository repo { get; set; }
        public TeamsViewComponent (IBowlingRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var teams = repo.Bowlers
                .Select(x => x.TeamID)
                .Distinct()
                .OrderBy(x => x);

            return View(teams);
        }
    }
}
