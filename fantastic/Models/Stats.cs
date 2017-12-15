using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace fantastic.Models
{
    public class Stats
    {
        public int Id { get; set; }
        public Athlete athlete { get; set; }
        public int game { get; set; }
        public int AthleteId { get; set; }
        public int Score { get; set; }
        public Team team { get; set; }
        public int teamId { get; set; }
        public int point { get; set; }
        public int rebound { get; set; }
        public int assist { get; set; }
        public int turnover { get; set; }
        public int touchdown { get; set; }
        public int passing_touchdown { get; set; }
        public int run { get; set; }
        public int hit { get; set; }
        public int rbi { get; set; }
        public int homerun { get; set; }
        public int error { get; set; }
        public int goal { get; set; }
        public DateTime Day { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}