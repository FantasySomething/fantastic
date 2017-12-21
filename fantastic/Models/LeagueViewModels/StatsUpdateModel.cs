using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace fantastic.Models.LeagueViewModels
{
    public class StatsUpdateModel
    {
        [Required]
        [Display(Name = "Game")]
        public int game { get; set; }

        [Required]
        [Display(Name = "Score")]
        public int Score { get; set; }

        [Required]
        [Display(Name = "Point")]
        public int point { get; set; }

        [Required]
        [Display(Name = "Rebound")]
        public int rebound { get; set; }

        [Required]
        [Display(Name = "Assist")]
        public int assist { get; set; }

        [Required]
        [Display(Name = "Touchdown")]
        public int touchdown { get; set; }

        [Required]
        [Display(Name = "Passing Touchdown")]
        public int passing_touchdown { get; set; }

        [Required]
        [Display(Name = "Touchdown")]
        public int yard { get; set; }

        [Required]
        [Display(Name = "Passing Touchdown")]
        public int passing_yard { get; set; }

        [Required]
        [Display(Name = "Turnover")]
        public int turnover { get; set; }

        [HiddenInput]
        public int athlete { get; set; }

    }
}
