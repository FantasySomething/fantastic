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
                Team ph = new Team(); //placeholder team for the league
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
                ph.athletes = new List<Athlete>();
                ph.CreatedAt = DateTime.Now;
                ph.UpdatedAt = DateTime.Now;
                ph.userId = newest.AdminId;
                ph.user = newest.Admin;
                ph.wins = 0;
                ph.losses = 0;
                ph.ties = 0;
                ph.Name = "Free Agents";
                ph.leagueId = newest.Id;
                ph.league = newest;
                newest.teams.Add(ph);
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
                model.allAthletes = _context.athletes.Where(a => a.LeagueId == ID).ToList();
                model.allTeams = _context.teams.Where(team => team.leagueId == ID).ToList();
                return View("admin", model);
            }
            else
            {
                DetailsViewModel model = new DetailsViewModel();
                model.current = _context.leagues.SingleOrDefault(l => l.Id == ID);
                model.user = _context.users.SingleOrDefault(user => user.Id == _userManager.GetUserId(User));
                model.allSports = _context.sports.ToList();
                model.allAthletes = _context.athletes.Where(a => a.LeagueId == ID).ToList();
                model.allTeams = _context.teams.Where(team => team.leagueId == ID).ToList();
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
            Team ph = _context.teams.SingleOrDefault(t => t.userId == current.AdminId && t.leagueId == current.Id);
            rookie.Name = data.newAthlete.name;
            rookie.SportId = data.newAthlete.sport;
            rookie.Sport = _context.sports.SingleOrDefault(s => s.Id == rookie.SportId);
            rookie.Season = data.newAthlete.season;
            rookie.CreatedAt = DateTime.Now;
            rookie.UpdatedAt = DateTime.Now;
            rookie.teamId = ph.Id;
            rookie.team = _context.teams.SingleOrDefault(t=>t.Id == ph.Id);            
            rookie.League = current;
            rookie.LeagueId = current.Id;
            if(ph.athletes == null)
            {
                ph.athletes = new List<Athlete>();
            }
            if(current.available == null)
            {
                current.available = new List<Athlete>();
            }
            ph.athletes.Add(rookie);
            current.available.Add(rookie);
            _context.athletes.Add(rookie);
            _context.SaveChanges();            
            return RedirectToAction("Details", new { ID = ID});
        }
        [HttpPost]
        [Route("league/addAthlete")]
        public IActionResult AddAthlete(AdminViewModel data)
        {
            Athlete guy = _context.athletes.SingleOrDefault(a => a.Id == data.addGuy.athlete);
            Team team = _context.teams.SingleOrDefault(t => t.Id == data.addGuy.team);
            guy.teamId = data.addGuy.team;
            guy.team = team;
            if(team.athletes == null)
            {
                team.athletes = new List<Athlete>();
            }
            team.athletes.Add(guy);
            _context.SaveChanges();
            int ID = guy.LeagueId;
            Console.WriteLine(data);
            return RedirectToAction("Details", new { ID = ID });
        }
        [HttpGet]
        [Route("league/delete/{ID}")]
        public IActionResult Delete(int ID)
        {
            League current = _context.leagues.SingleOrDefault(l => l.Id == ID);
            if (current.AdminId == _userManager.GetUserId(User))
            {
                _context.leagues.Remove(current);
                _context.SaveChanges();
                return RedirectToAction("Index", "");
            }
            else
            {
                return RedirectToAction("Details", new { ID = ID });
            }
        }
    }
}