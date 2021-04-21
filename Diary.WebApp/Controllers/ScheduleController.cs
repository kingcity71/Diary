using System;
using System.Collections.Generic;
using Diary.Models.Enums;
using Diary.Interfaces;
using Diary.Models;
using Diary.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Diary.WebApp.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly IScheduleService _scheduleService;
        private readonly ISpecialTaskService specialTaskService;
        private readonly IUserService _userService;
        private readonly IScoreService _scoreService;

        public ScheduleController(IScheduleService scheduleService,
            ISpecialTaskService specialTaskService,
            RoleManager<IdentityRole> roleManager, 
            IUserService userService, IScoreService scoreService)
            : base(roleManager)
        {
            _scheduleService = scheduleService;
            this.specialTaskService = specialTaskService;
            _userService = userService;
            _scoreService = scoreService;
        }

        [HttpPost("Schedule/UploadSpecialTask")]
        public IActionResult SpecialTaskUpload(SpecialTask specialTask)
        {
            try
            {
                specialTaskService.Create(specialTask);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        [HttpGet("Schedule/Bind/{scheduleId}/{fileId}")]
        public IActionResult Bind(Guid scheduleId, Guid fileId)
        {
            try
            {
                _scheduleService.BindLessonWithFile(scheduleId, fileId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
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
    
        public IActionResult Lesson(Guid schedId)
        {
            var lessonModel = _scheduleService.GetLesson(schedId);
            return View(lessonModel);
        }

        [HttpPost]
        public dynamic UpdateScores(IEnumerable<ScoreDTO> scores)
        {
            var scoreModels = new List<ScoreModel>();
            foreach (var score in scores)
            {
                var scoreModel = Activator.CreateInstance<ScoreModel>();
                scoreModel.Id = score.ScoreId;
                scoreModel.Comment = score.ScoreComment;
                scoreModel.ScheduleId = score.SchedId;
                scoreModel.StudentModel = new UserModel() { Id = score.StudentId };

                if (!Enum.TryParse(typeof(ScoreResult), score.ScoreType, out var type))
                    return new { Item1 = false, Item2 = "Укажите оценку всем ученикам!" };

                scoreModel.ScoreResult = (ScoreResult)type;

                scoreModels.Add(scoreModel);
            }

            _scoreService.Update(scoreModels);

            return new{Item1 = true, Item2 = "Данные успешно сохранены!"};
        }
    }
}