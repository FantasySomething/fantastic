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
        public int pts { get; set; }
        public int rebs { get; set; }
        public int assts { get; set; }
        public int to { get; set; }
        public int td { get; set; }
        public int runs { get; set; }
        public int hits { get; set; }
        public int rbi { get; set; }
        public int hr { get; set; }
        public int error { get; set; }
        public int goal { get; set; }
        public int assist { get; set; }
        public DateTime Day { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}