using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fantastic.Models.LeagueViewModels
{
    public class AdminViewModel
    {
        public League current { get; set; }
        public AthleteCreationModel newAthlete { get; set; }
        public AthleteAdditionModel addGuy { get; set; }
        public List<Sport> allSports  { get; set; }
        public List<Athlete> allAthletes { get; set; }
        public List<Team> allTeams { get; set; }
    }
}
