using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fantastic.Models.LeagueViewModels
{
    public class AthleteAdditionModel
    {
        [Required]
        [Display(Name = "Existing Athlete")]
        public Athlete athlete { get; set; }
    }
}
