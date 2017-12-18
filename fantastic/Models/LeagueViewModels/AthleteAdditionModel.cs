using Microsoft.AspNetCore.Mvc;
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
        public int team { get; set; }

        [HiddenInput]
        public int athlete { get; set; }
    }
}
