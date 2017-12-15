using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fantastic.Models.TeamViewModels;

namespace fantastic.Controllers
{
    public class TeamController : Controller
    {
        [HttpGet]
        [Route("team/create")]
        public IActionResult Create()
        {
            return View();
        }
    }
}