using System;
using Diary.Interfaces;
using Diary.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Diary.WebApp.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly IScheduleService _scheduleService;
        
        private readonly IUserService _userService;

        public ScheduleController(IScheduleService scheduleService, RoleManager<IdentityRole> roleManager, IUserService userService)
            : base(roleManager)
        {
            _scheduleService = scheduleService;
            _userService = userService;
        }

        [HttpGet("Schedule/Index")]
        public IActionResult Index()
            => View(new MonthScheduleViewModel(DateTime.Now.Month, DateTime.Now.Year));

        [HttpGet("Schedule/Index/{month}/{year}")]
        public IActionResult Index(int month, int year)
            => View(new MonthScheduleViewModel(month, year));

        [HttpGet("Schedule/DaySchedule/{year}/{month}/{day}")]
        public IActionResult DaySchedule(int year, int month, int day)
        {
            var dayDate = new DateTime(year, month, day);
            var role = GetUserRole();
            
            Guid? entityId = null;
            
            if (role != "Admin")
                entityId = _userService.GetUser(User.Identity.Name).Id;

            var scheduleModels = _scheduleService.GetSchedulesByDay(dayDate, role, entityId);

            var viewModel = new ScheduleDayViewModel();
            viewModel.ScheduleModels = scheduleModels;
            viewModel.Date = dayDate;

            return View(viewModel);
        }
    }
}