using Diary.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Newtonsoft.Json;
using Diary.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Diary.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        private string GetEncodedJwt(IEnumerable<Claim> claims)
        {
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        [HttpPost]
        public string Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                var errorText = "Invalid username or password.";
                return errorText;
            }

            var encodedJwt = GetEncodedJwt(identity.Claims);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return JsonConvert.SerializeObject(response);
        }

        [HttpPost]
        public bool CheckToken(string username, string token)
        {
            var user = GetIdentity(username, string.Empty);
            var computedToken = GetEncodedJwt(user.Claims);
            return token == computedToken;
        }

        [Authorize]
        public dynamic GetUser(string token)
        {
            var user = User.Identity;
            return null;
        }

        [Authorize]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин {User.Identity.Name}");
        }

        [Authorize]
        public IActionResult GetRole()
        {
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultRoleClaimType)?.Value ?? string.Empty;
            return Ok(role);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var person = _userService.GetUser(username);

            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
