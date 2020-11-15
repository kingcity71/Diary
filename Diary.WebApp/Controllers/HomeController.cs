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
    public class HomeController : BaseController
    {
        public HomeController(RoleManager<IdentityRole> roleManager)
            :base(roleManager){ }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            if(!User.IsInRole("Admin"))
            {
                var role = GetUserRole();
                return RedirectToAction($"{role}Profile", "Profile");
            }
            else
                return RedirectToAction("Index","Admin");
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
