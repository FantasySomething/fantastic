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
using fantastic.Models.LeagueViewModels;

namespace fantastic.Controllers
{
    public class LeagueController : Controller
    {
        [HttpGet]
        [Route("league/dashboard")]
        public IActionResult Dashboard()
        {
            IndexViewModel model = new IndexViewModel();
            return View(model);
        }
    }
}