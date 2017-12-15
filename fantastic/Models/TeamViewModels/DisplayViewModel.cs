using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fantastic.Models.TeamViewModels
{
    public class DisplayViewModel
    {
        public Team myTeam { get; set; }
        public League myLeague { get; set; }
        public List<Athlete> myPlayers { get; set; }
    }
}
