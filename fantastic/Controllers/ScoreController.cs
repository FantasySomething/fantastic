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
using Microsoft.EntityFrameworkCore;
using fantastic.Views;

namespace fantastic.Controllers
{
    public class ScoreController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public ScoreController(
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
        [Route("league/stats/{ID}")]
        public IActionResult Stats(int ID)
        {
            DetailsViewModel model = new DetailsViewModel();
            model.current = _context.leagues.SingleOrDefault(l => l.Id == ID);
            model.user = _context.users.SingleOrDefault(user => user.Id == _userManager.GetUserId(User));
            model.allAthletes = _context.athletes
                .Include(Athlete=>Athlete.team)
                .Include(Athlete => Athlete.Sport)
                .Where(z => z.LeagueId == ID)
                .ToList();
            return View(model);
        }

        [HttpGet]
        [Route("league/stats/athlete/{ID}")]
        public IActionResult AthleteStats(int ID)
        {
            StatsViewModel model = new StatsViewModel();
            model.current = _context.athletes.SingleOrDefault(l => l.Id == ID);
            League determine = _context.leagues.SingleOrDefault(l => l.Id == model.current.LeagueId);
            model.allStats = _context.stats.Include(s => s.athlete).ToList();
            if(determine.AdminId == _userManager.GetUserId(User))
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("AthleteStatsforAll", new { ID = ID });
            }
        }

        [HttpGet]
        [Route("league/stats/viewathlete/{ID}")]
        public IActionResult AthleteStatsforAll(int ID)
        {
            StatsViewModel model = new StatsViewModel();
            model.current = _context.athletes.SingleOrDefault(l => l.Id == ID);
            League determine = _context.leagues.SingleOrDefault(l => l.Id == model.current.LeagueId);
            model.allStats = _context.stats.Include(s => s.athlete).ToList();
            return View(model);
        }

        [HttpPost]
        [Route("athlete/updateStats")]
        public IActionResult UpdateStats(StatsViewModel data)
        {
            Athlete athlete = _context.athletes.SingleOrDefault(a => a.Id == data.updateStats.athlete);
            if (athlete.SportId == 1)
            {
                Stats pro_bball_stats = new Stats();
                pro_bball_stats.game = data.updateStats.game;
                pro_bball_stats.AthleteId = data.updateStats.athlete;
                pro_bball_stats.point = data.updateStats.point;
                float point = data.updateStats.point;
                pro_bball_stats.rebound = data.updateStats.rebound;
                float rebound = data.updateStats.rebound;
                pro_bball_stats.assist = data.updateStats.assist;
                float assist = data.updateStats.assist;
                pro_bball_stats.turnover = data.updateStats.turnover;
                float turnover = data.updateStats.turnover;
                double calculate_score = point * 0.75 + rebound * 1 + assist * 1 + turnover * -1;
                int score = (int)Math.Floor(calculate_score);
                pro_bball_stats.Score = score;
                _context.stats.Add(pro_bball_stats);
                decimal totalScore = (athlete.avgScore * athlete.totalGames) + score;
                athlete.avgScore = (int)Math.Floor(totalScore / (athlete.totalGames + 1));
                athlete.totalGames++;
                if (athlete.gameStats == null)
                {
                    athlete.gameStats = new List<Stats>();
                }
                athlete.gameStats.Add(pro_bball_stats);
                _context.SaveChanges();
                return RedirectToAction("AthleteStats", new { ID = athlete.Id});
            }
            else if (athlete.SportId == 2)
            {
                Stats bball_stats = new Stats();
                bball_stats.game = data.updateStats.game;
                bball_stats.AthleteId = data.updateStats.athlete;
                bball_stats.point = data.updateStats.point;
                bball_stats.rebound = data.updateStats.rebound;
                bball_stats.assist = data.updateStats.assist;
                bball_stats.turnover = data.updateStats.turnover;
                int score = data.updateStats.point * 2 + data.updateStats.rebound * 2 + data.updateStats.assist * 2 + data.updateStats.turnover * -1;
                bball_stats.Score = score;
                _context.stats.Add(bball_stats);
                int totalScore = (athlete.avgScore * athlete.totalGames) + score;
                athlete.avgScore = totalScore / (athlete.totalGames + 1);
                athlete.totalGames++;
                if (athlete.gameStats == null)
                {
                    athlete.gameStats = new List<Stats>();
                }
                athlete.gameStats.Add(bball_stats);
                _context.SaveChanges();
                return RedirectToAction("AthleteStats", new { ID = athlete.Id });
            }
            else if (athlete.SportId == 3)
            {
                Stats pro_fball_stats = new Stats();
                pro_fball_stats.game = data.updateStats.game;
                pro_fball_stats.AthleteId = data.updateStats.athlete;
                pro_fball_stats.touchdown = data.updateStats.touchdown;
                pro_fball_stats.passing_touchdown = data.updateStats.passing_touchdown;
                pro_fball_stats.yard = data.updateStats.yard;
                double yardz = data.updateStats.yard / 10;
                int converted_yard = (int)Math.Floor(yardz);
                pro_fball_stats.passing_yard = data.updateStats.passing_yard;
                double passing_yardz = data.updateStats.yard / 25;
                int converted_passing_yard = (int)Math.Floor(passing_yardz);
                pro_fball_stats.turnover = data.updateStats.turnover;
                int score = data.updateStats.touchdown * 14 + data.updateStats.passing_touchdown * 10 + converted_yard * 1 + converted_passing_yard * 1 + data.updateStats.turnover * -2;
                pro_fball_stats.Score = score;
                _context.stats.Add(pro_fball_stats);
                int totalScore = (athlete.avgScore * athlete.totalGames) + score;
                athlete.avgScore = totalScore / (athlete.totalGames + 1);
                athlete.totalGames++;
                if (athlete.gameStats == null)
                {
                    athlete.gameStats = new List<Stats>();
                }
                athlete.gameStats.Add(pro_fball_stats);
                _context.SaveChanges();
                return RedirectToAction("AthleteStats", new { ID = athlete.Id });
            }
            else if (athlete.SportId == 4)
            {
                Stats fball_stats = new Stats();
                fball_stats.game = data.updateStats.game;
                fball_stats.AthleteId = data.updateStats.athlete;
                fball_stats.touchdown = data.updateStats.touchdown;
                fball_stats.passing_touchdown = data.updateStats.passing_touchdown;
                fball_stats.turnover = data.updateStats.turnover;
                int score = data.updateStats.touchdown * 14 + data.updateStats.passing_touchdown * 10 + data.updateStats.turnover * -2;
                fball_stats.Score = score;
                _context.stats.Add(fball_stats);
                int totalScore = (athlete.avgScore * athlete.totalGames) + score;
                athlete.avgScore = totalScore / (athlete.totalGames + 1);
                athlete.totalGames++;
                if (athlete.gameStats == null)
                {
                    athlete.gameStats = new List<Stats>();
                }
                athlete.gameStats.Add(fball_stats);
                _context.SaveChanges();
                return RedirectToAction("AthleteStats", new { ID = athlete.Id });
            }
            return View();
        }
    }
}