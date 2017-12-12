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
        public int AthleteId { get; set; }
        public int Score { get; set; }
        public Team team { get; set; }
        public int teamId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
