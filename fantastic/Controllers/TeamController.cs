using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fantastic.Models.TeamViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using fantastic.Models;
using fantastic.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using fantastic.Models.AccountViewModels;
using fantastic.Models.LeagueViewModels;
using fantastic.Services;

namespace fantastic.Controllers
{
    public class TeamController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public TeamController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            ApplicationDbContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        [Route("team/create/{ID}")]
        public IActionResult Create(int ID)
        {
            TCViewModel model = new TCViewModel();
            model.current = _context.leagues.SingleOrDefault(l => l.Id == ID);
            return View(model);
        }

        [HttpPost]
        [Route("team/addTeam")]
        public IActionResult AddTeam(TCViewModel incoming)
        {
            Team next = new Team();
            next.Name = incoming.TC.Name;
            next.leagueId = incoming.TC.league;
            next.league = _context.leagues.SingleOrDefault(l => l.Id == next.leagueId);
            next.userId = _userManager.GetUserId(User);
            next.user = _context.Users.SingleOrDefault(u => u.Id == next.userId);
            next.CreatedAt = DateTime.Now;
            next.UpdatedAt = DateTime.Now;
            next.wins = 0;
            next.losses = 0;
            next.ties = 0;
            next.athletes = new List<Athlete>();
            _context.teams.Add(next);
            next.league.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Details", "League", new { ID = next.leagueId });
        }

        [HttpGet]
        [Route("team/display/{ID}")]
        public IActionResult Display(int ID)
        {
            DisplayViewModel model = new DisplayViewModel();
            model.myTeam = _context.teams.SingleOrDefault(t => t.Id == ID);
            model.myPlayers = _context.athletes.Where(a => a.teamId == ID).ToList();
            model.myLeague = _context.leagues.SingleOrDefault(l => l.Id == model.myTeam.leagueId);
            return View(model);
        }
    }
}