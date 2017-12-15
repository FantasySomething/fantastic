using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fantastic.Models.TeamViewModels
{
    public class TeamCreationModel
    {
        [Required]
        [Display(Name = "League Name")]
        public string Name { get; set; }
    }
}
