using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fantastic.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int JoinCount { get; set; }
        public int WinCount { get; set; }
        public int Level { get; set; }
        [InverseProperty("Admin")]
        public List<League> leagues { get; set; }
        public List<Team> teams { get; set; }
        [InverseProperty("Winner")]
        public List<League> wins { get; set; }
        public ApplicationUser()
        {
            JoinCount = 0;
            WinCount = 0;
            List<League> wins = new List<League>();
            List<League> leagues = new List<League>();
            List<Team> teams = new List<Team>();
        }
    }
}
