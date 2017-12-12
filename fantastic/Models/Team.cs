using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace fantastic.Models
{
    public class Team
    {
        public int Id { get; set; }
        public League league { get; set; }
        public int leagueId { get; set; }
        public ApplicationUser user { get; set; }
        public int userId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Athlete> athletes { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }

        public Team()
        {
            List<Athlete> athletes = new List<Athlete>();
        }
    }
}
