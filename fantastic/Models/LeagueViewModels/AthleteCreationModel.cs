using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace fantastic.Models.LeagueViewModels
{
    public class AthleteCreationModel
    {
        [Required]
        [Display(Name = "Sport")]
        public int sport { get; set; }

        [Required]
        [Display(Name = "Season")]
        public int season { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [HiddenInput]
        public int league { get; set; }

    }
}
