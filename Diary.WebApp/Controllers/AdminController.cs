using Diary.Interfaces;
using Diary.Models;
using Diary.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.WebApp.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IParentService _parentService;
        private readonly IClassService _classService;

        public AdminController(RoleManager<IdentityRole> roleManager,
            IUserService userService,
            IStudentService studentService,
            ITeacherService teacherService,
            IParentService parentService,
            IClassService classService) : base(roleManager)
        {
            _userService = userService;
            _studentService = studentService;
            _teacherService = teacherService;
            _parentService = parentService;
            _classService = classService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserList()
        {
            var models = _userService.GetAllUsers();
            return View(models);
        }
        [HttpGet]
        public IActionResult StudentEdit(Guid id)
        {
            var studentModel = _studentService.GetStudentModel(id);
            var studentDTO = Activator.CreateInstance<StudentDTO>();

            studentDTO.Id = studentModel.Id;
            studentDTO.Login = studentModel.Login;
            studentDTO.Name = studentModel.Name;
            studentDTO.Parent1Id =  studentModel.Parents.FirstOrDefault()?.Id ?? Guid.Empty;
            studentDTO.Parent1Name =  studentModel.Parents.FirstOrDefault()?.Name;
            studentDTO.Parent2Id = studentModel.Parents.Count() > 1 ? studentModel.Parents.LastOrDefault()?.Id ?? Guid.Empty : Guid.Empty;
            studentDTO.Parent2Name = studentModel.Parents.Count() > 1 ? studentModel.Parents.LastOrDefault()?.Name : string.Empty;
            studentDTO.BirthDate = studentModel.BirthDate;
            studentDTO.ClassId = studentModel.ClassModel.Id;
            studentDTO.Classes = _classService.GetClasses()
                .ToDictionary(x=>x.Id, y=>y.FullName);

            return View(studentDTO);
        }
        [HttpPost]
        public IActionResult StudentEdit(StudentDTO studentDTO)
        {
            if (string.IsNullOrEmpty(studentDTO.Name) || studentDTO.BirthDate < new DateTime(1990, 1, 1))
            {
                studentDTO.Classes = _classService.GetClasses().ToDictionary(x => x.Id, y => y.FullName);
                studentDTO.IsInvalid = true;
                return View(studentDTO);
            }

            if (string.IsNullOrEmpty(studentDTO.Parent1Name))
                studentDTO.Parent1Id = Guid.Empty;
            if (string.IsNullOrEmpty(studentDTO.Parent2Name))
                studentDTO.Parent2Id = Guid.Empty;

            var studentModel = new StudentModel()
            {
                Id = studentDTO.Id,
                Login = studentDTO.Login,
                BirthDate = studentDTO.BirthDate,
                ClassModel = new ClassModel() { Id = studentDTO.ClassId },
                Name = studentDTO.Name,
                Parents = new List<ParentModel>
                {
                    new ParentModel{Id = studentDTO.Parent1Id},
                    new ParentModel{Id = studentDTO.Parent2Id}
                }
            };

            _studentService.Update(studentModel);

            return RedirectToAction("UserList", "Admin");
        }

        public IActionResult TeacherEdit(Guid id)
        {
            var teacherModel = _teacherService.GetTeacherModel(id);
            return View(teacherModel);
        }
        public IActionResult ParentEdit(Guid id)
        {
            var parentModel = _parentService.GetParentModel(id);
            return View(parentModel);
        }

        [HttpGet]
        public IEnumerable<UserModel> SearchParents(string key)
        {
            var users = _userService.SearchUsers(key).Where(x=>x.Role=="Parent").ToList();
            return users;
        }
        public IEnumerable<UserModel> SearchUsers(string key) 
        {
            var users = _userService.SearchUsers(key).ToList();
            return users;
        }
    }
}
