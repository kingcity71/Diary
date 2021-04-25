using Diary.Interfaces;
using Diary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Diary.WebApp.Controllers
{
    public class STAController : BaseController
    {
        private readonly ISpecialTaskAnswerSerivce _spaService;
        private readonly IUserService _userService;

        public STAController(RoleManager<IdentityRole> roleManager, ISpecialTaskAnswerSerivce spaService, IUserService userService)
            : base(roleManager)
        {
            _spaService = spaService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create(SpecialTaskAnswer spa)
        {
            spa.StudentId = _userService.GetUser(GetCurrentUser()).Id;
            try
            {
                _spaService.Create(spa);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("STA/Answer")]
        public IActionResult Answer(Guid spaId)
        {
            try
            {
                _spaService.Delete(spaId);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("STA/File")]
        public IActionResult File(Guid spaId)
        {
            try
            {
                _spaService.DeleteFile(spaId);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPatch("STA/File")]
        public IActionResult File(Guid spaId, Guid newFileId)
        {
            try
            {
                _spaService.UpdateFile(spaId, newFileId);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPatch("STA/Answer")]
        public IActionResult Answer(SpecialTaskAnswer spa)
        {
            var curUserId= _userService.GetUser(GetCurrentUser()).Id;
            if (User.IsInRole("Teacher"))
                spa.TeacherId = curUserId;
            try
            {
                _spaService.Update(spa);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
