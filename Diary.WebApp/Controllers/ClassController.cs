using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diary.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diary.WebApp.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }
        public IActionResult Index(Guid id)
        {
            var classModel = _classService.GetClassModel(id);
            return View(classModel);
        }

        public IActionResult ClassList()
        {
            var classes = _classService.GetClasses();
            return View(classes);
        }
    }
}