using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace fantastic.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdminId { get; set; }
        public ApplicationUser Admin { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string winnerId { get; set; }
        public ApplicationUser winner { get; set; }
        public int Length { get; set; }
        public int UnitTime { get; set; }
        public List<Team> teams { get; set; }
        public List<Athlete> available { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public League()
        {
            List<Team> teams = new List<Team>();
            List<Athlete> available = new List<Athlete>();
        }
    }
}
