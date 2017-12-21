using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fantastic.Models.LeagueViewModels
{
    public class StatsViewModel
    {
        public Athlete current { get; set; }
        public List<Stats> allStats { get; set; }
        public StatsUpdateModel updateStats { get; set; }
    }
}
