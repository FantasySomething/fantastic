using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using fantastic.Models;
using fantastic.Models.AccountViewModels;
using fantastic.Models.LeagueViewModels;
using fantastic.Services;
using fantastic.Data;

namespace fantastic.Controllers
{
    public class LeagueController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public LeagueController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        [HttpGet]
        [Route("league/dashboard")]
        public IActionResult Dashboard()
        {
            NewLeague model = new NewLeague();
            return View(model);
        }
        [HttpPost]
        [Route("league/create")]
        public IActionResult Create(NewLeague data)
        {
            string id = _userManager.GetUserId(User);
            NewLeague newbie = new NewLeague();
            newbie = data;
            TryValidateModel(newbie);
            if (ModelState.IsValid)
            {
                League newest = new League();
                newest.Name = data.Name;
                newest.StartDate = data.Start;
                newest.EndDate = data.End;
                newest.CreatedAt = DateTime.Now;
                newest.UpdatedAt = DateTime.Now;
                newest.Admin = _context.users.SingleOrDefault(user => user.Id == id);
                newest.AdminId = id;
                newest.UnitTime = data.Duration;
                newest.available = new List<Athlete>();
                newest.teams = new List<Team>();
                _context.leagues.Add(newest);
                _context.SaveChanges();
                return RedirectToAction("Index", "");
            }
            return View("Dashboard", data);
        }
        [HttpGet]
        [Route("league/details/{ID}")]
        public IActionResult Details(int ID)
        {
            League current = _context.leagues.SingleOrDefault(l => l.Id == ID);
            if (current.AdminId == _userManager.GetUserId(User))
            {
                AdminViewModel model = new AdminViewModel();
                model.current = _context.leagues.SingleOrDefault(l => l.Id == ID);
                model.allSports = _context.sports.ToList();
                model.allAthletes = _context.athletes.Where(a => a.LeagueId == ID).Where(a=>a.teamId==0).ToList();
                model.allTeams = _context.teams.Where(team => team.leagueId == ID).ToList();
                return View("admin", model);
            }
            else
            {
                DetailsViewModel model = new DetailsViewModel();
                model.current = _context.leagues.SingleOrDefault(l => l.Id == ID);
                model.user = _context.users.SingleOrDefault(user => user.Id == _userManager.GetUserId(User));
                model.allSports = _context.sports.ToList();
                return View(model);
            }
        }
        [HttpPost]
        [Route("league/newAthlete")]
        public IActionResult NewAthlete(AdminViewModel data)
        {
            int ID = data.newAthlete.league;
            Athlete rookie = new Athlete();
            League current = _context.leagues.SingleOrDefault(l => l.Id == data.newAthlete.league);
            rookie.Name = data.newAthlete.name;
            rookie.SportId = data.newAthlete.sport;
            rookie.Sport = _context.sports.SingleOrDefault(s => s.Id == rookie.SportId);
            rookie.Season = data.newAthlete.season;
            rookie.CreatedAt = DateTime.Now;
            rookie.UpdatedAt = DateTime.Now;
            rookie.teamId = 1;
            rookie.team = _context.teams.SingleOrDefault(t=>t.Id == 0);
            rookie.League = current;
            rookie.LeagueId = current.Id;
            Team team = _context.teams.SingleOrDefault(t => t.Id == 0);
            team.user = _context.Users.SingleOrDefault(u => u.Id == team.userId);
            if(team.athletes == null)
            {
                team.athletes = new List<Athlete>();
            }
            if(current.available == null)
            {
                current.available = new List<Athlete>();
            }
            team.athletes.Add(rookie);
            current.available.Add(rookie);
            _context.athletes.Add(rookie);
            _context.SaveChanges();            
            return RedirectToAction("Details", new { ID = ID});
        }
        [HttpPost]
        [Route("league/addAthlete")]
        public IActionResult AddAthlete(AdminViewModel data)
        {
            Console.WriteLine(data);
            return View();
        }
    }
}