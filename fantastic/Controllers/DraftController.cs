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

namespace fantastic.Controllers
{
    public class LeagueController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LeagueController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
            NewLeague newbie = new NewLeague();
            newbie = data;
            TryValidateModel(newbie);
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "HomeController");
            }
            return View("Dashboard", data);
        }
    }
}