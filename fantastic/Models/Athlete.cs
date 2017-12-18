using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace fantastic.Models
{
    public class Athlete
    {
        public int Id { get; set; }
        public Sport Sport { get; set; }
        public int SportId { get; set; }
        public League League { get; set; }
        public int LeagueId { get; set; }
        public Team team { get; set; }
        public int teamId { get; set; }
        public int Season { get; set; }
        public string Name { get; set; }
        public int totalGames { get; set; }
        public int avgScore { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}
