using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Diary.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Diary.Identity;
using System;
using Diary.Entities.Enums;
using System.Linq;
using Diary.Interfaces;
using Diary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Diary.WebApp
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userService = userService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            var registerModel = Activator.CreateInstance<RegisterViewModel>();

            registerModel.Roles = new SelectList(Enum.GetNames(typeof(UserRole)).Where(x => x != "Admin").ToList());

            return View(registerModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var login = _userService.GetGeneratedLogin(model.Role);
                var user = Activator.CreateInstance<User>();
                user.UserName = login;

                // Работа с Identity
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                user = await _userManager.FindByNameAsync(login);
                // добавляем роль
                await _userManager.AddToRoleAsync(user, model.Role);

                // Работа с данными приложения
                var userModel = Activator.CreateInstance<UserModel>();
                userModel.Name = model.Name;
                userModel.Login = login;
                userModel.Role = model.Role;
                _userService.CreateUser(userModel);

                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
            }
            model.Roles = new SelectList(Enum.GetNames(typeof(UserRole)).Where(x => x != "Admin").ToList());
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
            => View(new LoginViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}