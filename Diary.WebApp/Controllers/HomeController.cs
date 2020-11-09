using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Diary.WebApp.Models;
using Microsoft.Extensions.Configuration;
using Diary.Interfaces;
using Diary.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Diary.Entities.Enums;

namespace Diary.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _options;
        private readonly IRepository<User> repository;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(ILogger<HomeController> logger, 
            IConfiguration options, IRepository<User> repository,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _options = options;
            this.repository = repository;
            this.roleManager = roleManager;
        }

        [Authorize]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин {User.Identity.Name}");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult GetRole()
        {
            return Ok($"Ваша роль админ");
        }

        public IActionResult Index()
        {
            foreach(var item in typeof(UserRole).GetEnumNames())
            {
                roleManager.CreateAsync(new IdentityRole(item)).GetAwaiter().GetResult();
            }
            var user = User.Identity;
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
