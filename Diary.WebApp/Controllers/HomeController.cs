using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Diary.WebApp.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Diary.Interfaces;
using Diary.Entities;

namespace Diary.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _options;
        private readonly IRepository<AppUser> repository;

        public HomeController(ILogger<HomeController> logger, IConfiguration options, IRepository<AppUser> repository)
        {
            _logger = logger;
            _options = options;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var q = repository.GetAllItems();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
