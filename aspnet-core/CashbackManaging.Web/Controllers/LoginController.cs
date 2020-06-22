using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using CashbackManaging.Model;
using CashbackManaging.Model.Entities;
using CashbackManaging.Service;
using CashbackManaging.Utility;
using CashbackManaging.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CashbackManaging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        public LoginController(ApplicationDbContext dbContext, UserManagerService userManager)
        {
            DbContext = dbContext;
            UserManager = userManager;
        }

        private ApplicationDbContext DbContext { get; }

        private UserManagerService UserManager { get; }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await DbContext.Users.FirstOrDefaultAsync(u => u.UserName == model.Login);

            if (user == null)
                return BadRequest("Пользователь с данным логином не найден");

            if (!await UserManager.CheckPasswordAsync(user, model.Password))
                return BadRequest("Неверный пароль");

            var encodedJwt = UserManager.GetUserToken(user);

            var response = new
            {
                access_token = encodedJwt,
                username = user.UserName,
                expires = DateTime.Now.AddMinutes(AuthOptions.LIFETIME)
            };

            return Json(response);
        }
    }
}