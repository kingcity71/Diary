using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diary.Interfaces;
using Diary.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Diary.WebApp.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;
        private readonly IParentService _parentService;

        public ProfileController(RoleManager<IdentityRole> roleManager, 
            IUserService userService, 
            IStudentService studentService,
            IParentService parentService):base(roleManager)
        {
            _userService = userService;
            _studentService = studentService;
            _parentService = parentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StudentProfile(Guid? id)
        {
            var studentModel = id != null ? _studentService.GetStudentModel(id.Value) : _studentService.GetStudentModel(User.Identity.Name);
            return View(studentModel);
        }

        public IActionResult ParentProfile(Guid? id)
        {
            var parentModel = id != null ? _parentService.GetParentModel(id.Value) : _parentService.GetParentModel(User.Identity.Name);
            return View(parentModel);
        }
    }
}