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
        [Route("draft/dashboard")]
        public IActionResult Dashboard()
        {
            NewLeague model = new NewLeague();
            return View(model);
        }
        [HttpPost]
        [Route("draft/create")]
        public IActionResult Create(NewLeague data)
        {
            string id = _userManager.GetUserId(User);
            NewLeague newbie = new NewLeague();
            newbie = data;
            TryValidateModel(newbie);
            if (ModelState.IsValid)
            {
                League newest = new League();
                newest.StartDate = data.Start;
                newest.EndDate = data.End;
                newest.CreatedAt = DateTime.Now;
                newest.UpdatedAt = DateTime.Now;
                newest.Admin = _context.users.SingleOrDefault(user => user.Id == id);
                newest.AdminId = id;
                newest.UnitTime = data.Duration;
                newest.available = new List<Athlete>();
                _context.leagues.Add(newest);
                _context.SaveChanges();
                return RedirectToAction("Index", "");
            }
            return View("Dashboard", data);
        }
    }
}