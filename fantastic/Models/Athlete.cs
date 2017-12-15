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
        public Season Season { get; set; }
        public int SeasonId { get; set; }
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}
