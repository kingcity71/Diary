using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Diary.WebApp.Controllers
{
    public class BaseController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public BaseController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        protected string GetUserRole()
        {
            var roles = _roleManager.Roles;
            foreach (var role in roles)
                if (User.IsInRole(role.Name))
                    return role.Name;
            return null;
        }
      
    }
}