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

        [HttpPost]
        [Route("athlete/{ID}")]
        public IActionResult UpdateStats(int ID, Stats data)
        {
            Athlete athlete = _context.athletes.SingleOrDefault(a => a.Id == ID);
            if (athlete.SportId == 1)
            {
                Stats pro_bball_stats = new Stats();
                pro_bball_stats.game = data.game;
                pro_bball_stats.AthleteId = ID;
                pro_bball_stats.point = data.point;
                float point = data.point;
                pro_bball_stats.rebound = data.rebound;
                float rebound = data.rebound;
                pro_bball_stats.assist = data.assist;
                float assist = data.assist;
                pro_bball_stats.turnover = data.turnover;
                float turnover = data.turnover;
                double calculate_score = point * 0.75 + rebound * 1 + assist * 1 + turnover * -1;
                int score = (int)Math.Floor(calculate_score);
                pro_bball_stats.Score = score;
                _context.stats.Add(pro_bball_stats);
                _context.SaveChanges();
                return RedirectToAction();
            }
            else if (athlete.SportId == 2)
            {
                Stats bball_stats = new Stats();
                bball_stats.game = data.game;
                bball_stats.AthleteId = ID;
                bball_stats.point = data.point;
                bball_stats.rebound = data.rebound;
                bball_stats.assist = data.assist;
                bball_stats.turnover = data.turnover;
                int score = data.point * 2 + data.rebound * 2 + data.assist * 2 + data.turnover * -1;
                bball_stats.Score = score;
                _context.stats.Add(bball_stats);
                _context.SaveChanges();
                return RedirectToAction();
            }
            else if (athlete.SportId == 3)
            {
                Stats pro_fball_stats = new Stats();
                pro_fball_stats.game = data.game;
                pro_fball_stats.AthleteId = ID;
                pro_fball_stats.touchdown = data.touchdown;
                pro_fball_stats.passing_touchdown = data.passing_touchdown;
                pro_fball_stats.yard = data.yard;
                double yardz = data.yard / 10;
                int converted_yard = (int)Math.Floor(yardz);
                pro_fball_stats.passing_yard = data.passing_yard;
                double passing_yardz = data.yard / 25;
                int converted_passing_yard = (int)Math.Floor(passing_yardz);
                pro_fball_stats.turnover = data.turnover;
                int score = data.touchdown * 14 + data.passing_touchdown * 10 + converted_yard * 1 + converted_passing_yard * 1 + data.turnover * -2;
                pro_fball_stats.Score = score;
                _context.stats.Add(pro_fball_stats);
                _context.SaveChanges();
                return RedirectToAction();
            }
            else if (athlete.SportId == 4)
            {
                Stats fball_stats = new Stats();
                fball_stats.game = data.game;
                fball_stats.AthleteId = ID;
                fball_stats.touchdown = data.touchdown;
                fball_stats.passing_touchdown = data.passing_touchdown;
                fball_stats.turnover = data.turnover;
                int score = data.touchdown * 14 + data.passing_touchdown * 10 + data.turnover * -2;
                fball_stats.Score = score;
                _context.stats.Add(fball_stats);
                _context.SaveChanges();
                return RedirectToAction();
            }
            return View();
        }
    }
}