using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fantastic.Models;
using fantastic.Models.AccountViewModels;
using fantastic.Data;
using Microsoft.AspNetCore.Identity;

namespace fantastic.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();
            if(_signInManager.IsSignedIn(User))
            {
                model.myLeagues = _context.leagues.Where(l => l.AdminId == _userManager.GetUserId(User)).ToList();
            }
            else
            {
                model.aLeagues = _context.leagues.Where(l => l.StartDate > DateTime.Now).ToList();
            }
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
