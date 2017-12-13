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
        [Route("draft/dashboard")]
        public IActionResult Dashboard()
        {
            IndexBundle model = new IndexBundle();
            return View(model);
        }
        [HttpPost]
        [Route("draft/create")]
        public IActionResult Create(IndexBundle data)
        {
            NewLeague newbie = new NewLeague();
            newbie = data.create;
            TryValidateModel(newbie);
            if(ModelState.IsValid)
            {
                return View();
            }
            return View("Draft", data);
        }
    }
}