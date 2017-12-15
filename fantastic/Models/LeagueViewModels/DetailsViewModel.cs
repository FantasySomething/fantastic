using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fantastic.Models.LeagueViewModels
{
    public class DetailsViewModel
    {
        public League current { get; set; }
        public ApplicationUser user { get; set; }
        public AthleteCreationModel newAthlete { get; set; }
        public AthleteAdditionModel addAthlete { get; set; }
        public List<Sport> allSports { get; set; }
    }
}
